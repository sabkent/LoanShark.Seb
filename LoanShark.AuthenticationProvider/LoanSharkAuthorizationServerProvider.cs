using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace LoanShark.AuthenticationProvider
{
    /// <summary>
    /// http://leastprivilege.com/2013/11/13/embedding-a-simple-usernamepassword-authorization-server-in-web-api-v2/
    /// </summary>
    public class LoanSharkAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity("AccountManagement");

            context.Validated(identity);
        }
    }
}
