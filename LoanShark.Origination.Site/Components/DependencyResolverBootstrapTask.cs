using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using LoanShark.Application;

namespace LoanShark.Origination.Site.Components
{
    public class DependencyResolverBootstrapTask : IBootstrapTask
    {
        private readonly ILifetimeScope _lifetimeScope;

        public DependencyResolverBootstrapTask(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public void Run()
        {
            GlobalConfiguration.Configure((httpConfiguration) =>
            {
                httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(_lifetimeScope);
            });
        }
    }
}