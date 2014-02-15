using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;

namespace LoanShark.AuthenticationProvider
{
    public class LoanSharkAuthenticationHandler : AuthenticationHandler<LoanSharkAuthenticationOptions>
    {
        
        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            return new AuthenticationTicket(new ClaimsIdentity("LoanShark"), null);
        }

        protected override Task ApplyResponseChallengeAsync()
        {
            return Task.FromResult<object>(null);
        }
    }
}
