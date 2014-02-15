using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace LoanShark.AuthenticationProvider
{
    public static class AppBuilderExtensions
    {
        public static void UseLoanSharkAuthentication(this IAppBuilder appBuilder)
        {
            //appBuilder.Use<LoanSharkAuthenticationMiddleware>(new LoanSharkAuthenticationOptions());
            
        }
    }
}
