using LoanShark.AuthenticationProvider;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace LoanShark.AuthenticationServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var authBearerAuthenticationOptions = new OAuthBearerAuthenticationOptions
            {
                AuthenticationType = "Bearer",
                AuthenticationMode = AuthenticationMode.Active
            };

            appBuilder.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/api/token"),
                Provider = new LoanSharkAuthenticationServer(),
                AllowInsecureHttp = true
            });

            
            appBuilder.UseOAuthBearerAuthentication(authBearerAuthenticationOptions);
        }
    }
}