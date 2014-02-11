using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;

namespace LoanShark.Api
{
    public class TokenValidator : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var headers = request.Headers;

            if (headers.Authorization != null)
            {
                if (headers.Authorization.Scheme.Equals("Bearer"))
                {
                    var tf = Startup.OAuthBearerAuthenticationOptions.AccessTokenFormat;

                    var ticket = tf.Unprotect(headers.Authorization.Parameter);

                    

                    var identity = new ClaimsIdentity("");
                    var principal = new ClaimsPrincipal(identity);

                    //Thread.CurrentPrincipal = principal;
                    //if (HttpContext.Current != null)
                    //    HttpContext.Current.User = principal;
                }
            }

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Bearer", "error=\"invalid_token\""));
            }

            return response;
        }
    }
}