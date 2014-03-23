using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace LoanShark.Api
{
    public static class ContainerConfig
    {
        public static void Configure()
        {
            var containerBuilder = new ContainerBuilder();

            var executingAssembly = Assembly.GetExecutingAssembly();

            containerBuilder.RegisterApiControllers(executingAssembly);
            containerBuilder.RegisterAssemblyModules(executingAssembly);
            containerBuilder.RegisterModule(new LoanShark.Infrastructure.ContainerModule());
            var container = containerBuilder.Build();

            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}