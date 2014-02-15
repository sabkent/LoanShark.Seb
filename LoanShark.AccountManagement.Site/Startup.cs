using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoanShark.AuthenticationProvider;
using Owin;

namespace LoanShark.AccountManagement.Site
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseLoanSharkAuthentication();
        }
    }
}