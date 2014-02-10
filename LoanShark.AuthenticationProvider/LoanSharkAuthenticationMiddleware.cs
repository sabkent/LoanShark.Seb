using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;

namespace LoanShark.AuthenticationProvider
{
    public class LoanSharkAuthenticationMiddleware : AuthenticationMiddleware<LoanSharkAuthenticationOptions>
    {
        public LoanSharkAuthenticationMiddleware(OwinMiddleware next, LoanSharkAuthenticationOptions options)
            : base(next, options)
        {
        }

        protected override AuthenticationHandler<LoanSharkAuthenticationOptions> CreateHandler()
        {
            
        }
    }
}
