using LoanShark.AuthenticationProvider;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanShark.AccountManagement.Site
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseLoanSharkAuthentication();
        }
    }
}