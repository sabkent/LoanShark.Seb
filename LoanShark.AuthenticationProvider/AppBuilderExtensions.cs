using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace LoanShark.AuthenticationProvider
{
    public static class AppBuilderExtensions
    {
        public static void UseLoanSharkAuthentication(this IAppBuilder appBuilder)
        {
            appBuilder.Use<LoanSharkAuthenticationMiddleware>(new LoanSharkAuthenticationOptions());
        }
    }
}
