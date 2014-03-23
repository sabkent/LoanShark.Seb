using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Messaging.ClientSide
{
    public class LoanApplicationsHub : Hub
    {
        public void Test()
        {
            Clients.All.test();
        }
    }
}
