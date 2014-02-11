using LoanShark.AuthenticationProvider;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace LoanShark.Api
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerAuthenticationOptions { get; private set; }
        
        public void Configuration(IAppBuilder appBuilder)
        {
            OAuthBearerAuthenticationOptions = new OAuthBearerAuthenticationOptions
            {
                AuthenticationType = "Bearer",
                AuthenticationMode = AuthenticationMode.Active,
                
            };

            appBuilder.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true
                
            });

            appBuilder.UseOAuthBearerAuthentication(OAuthBearerAuthenticationOptions);
        }
    }
}