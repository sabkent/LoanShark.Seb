using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;

namespace LoanShark.AuthenticationProvider
{
    public class LoanSharkAuthenticationHandler : AuthenticationHandler<LoanSharkAuthenticationOptions>
    {
        
        protected override Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            throw new NotImplementedException();
        }
    }
}
