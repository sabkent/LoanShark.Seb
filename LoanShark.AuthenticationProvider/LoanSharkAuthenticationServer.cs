using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;

namespace LoanShark.AuthenticationProvider
{
    /// <summary>
    /// http://gkulshrestha.wordpress.com/2014/01/05/oauth-resource-owner-password-credentials-grant-flow-with-owinkatana/
    /// </summary>
    public class LoanSharkAuthenticationServer : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId, clientSecret;
            //context.TryGetBasicCredentials
            context.TryGetFormCredentials(out clientId, out clientSecret);

            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var claims = new List<Claim> {new Claim("userId", "1")};
            context.Validated(new ClaimsIdentity(claims, "LoanShark"));
        }
    }
}
