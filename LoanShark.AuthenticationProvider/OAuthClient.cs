using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.AuthenticationProvider
{
    public class OAuthClient
    {
        private readonly HttpClient _httpClient;
        
        public OAuthClient(Uri authenticationServer)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = authenticationServer;
        }

        public async Task<TokenResponse> RequestResourceOwnerPasswordAsync(string userName, string password)
        {
            var fields = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                {"username", userName},
                {"password", password}
            };

            var response = await _httpClient.PostAsync(String.Empty, new FormUrlEncodedContent(fields));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return new TokenResponse(content);
        }
    }
}
