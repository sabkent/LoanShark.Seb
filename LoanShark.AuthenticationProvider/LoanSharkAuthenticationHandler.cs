using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;

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
