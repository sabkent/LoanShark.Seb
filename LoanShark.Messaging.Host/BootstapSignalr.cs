using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using LoanShark.Application;

namespace LoanShark.Messaging.Host
{
    public class BootstapSignalr : IBootstrapTask
    {
        private IComponentContext _componentContext;

        public BootstapSignalr(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void Run()
        {
            
        }
    }
}
