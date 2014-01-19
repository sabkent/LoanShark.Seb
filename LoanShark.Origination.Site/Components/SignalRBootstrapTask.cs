using Autofac;
using Autofac.Integration.SignalR;
using LoanShark.Application;
using Microsoft.AspNet.SignalR;

namespace LoanShark.Origination.Site.Components
{
    public class SignalRBootstrapTask : IBootstrapTask
    {
        private readonly ILifetimeScope _lifetimeScope;

        public SignalRBootstrapTask(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public void Run()
        {
            GlobalHost.DependencyResolver = new AutofacDependencyResolver(_lifetimeScope);
        }
    }
}