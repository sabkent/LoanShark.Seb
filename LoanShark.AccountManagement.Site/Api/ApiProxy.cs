using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LoanShark.AuthenticationProvider;

namespace LoanShark.AccountManagement.Site.Api
{
    public class ApiProxy
    {
        private HttpClientFactory _httpClientFactory;
        
        public ApiProxy()
        {
            _httpClientFactory = new HttpClientFactory(new TokenRepository());
        }

        public async Task<T> Get<T>(string uri)
        {
            using (var httpClient =  await _httpClientFactory.Create())
            {
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response =  await httpClient.GetAsync(uri);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return await response.Content.ReadAsAsync<T>();
            }
        }
    }

    /// <summary>
    /// Get the token from some token store abstraction
    /// uses this token to construct the httpclient
    /// read the configuration for service base url
    /// </summary>
    public class HttpClientFactory
    {
        private ITokenRepository _tokens;

        public HttpClientFactory(ITokenRepository tokens)
        {
            _tokens = tokens;
        }

        public async Task<HttpClient> Create()
        {
            var token = _tokens.Get("some identuifer");
            if (token == null || token.IsValid() == false)
            {
                var authClient = new OAuthClient(new Uri("http://localhost:11754/api/token"));
                token = await authClient.RequestResourceOwnerPasswordAsync("seb", "bob");
                _tokens.Add(token);
            }

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:12274/api/");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            return httpClient;
        }
    }

    public interface ITokenRepository
    {
        TokenResponse Get(string serviceBaseAddressIdentitfier);
        void Add(TokenResponse token);
    }

    /// <summary>
    /// obv this impl is RED DICK u less
    /// 
    /// </summary>
    public class TokenRepository : ITokenRepository
    {
        private TokenResponse _token;

        public TokenResponse Get(string serviceBaseAddressIdentitfier)
        {
            return _token;
        }

        public void Add(TokenResponse token)
        {
            _token = token;
        }
    }

}