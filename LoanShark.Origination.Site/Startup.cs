using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;

namespace LoanShark.Origination.Site
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.MapSignalR();
        }
    }
}