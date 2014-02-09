using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using LoanShark.Messaging.ClientSide;

namespace LoanShark.Origination.Site
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            AppDomain.CurrentDomain.Load(typeof(LoanApplicationsHub).Assembly.FullName);
            appBuilder.MapSignalR();
        }
    }
}