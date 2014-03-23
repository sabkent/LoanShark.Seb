using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace LoanShark.AccountManagement.Site
{
    public static class ContainerConfig
    {
        public static void Configure()
        {
            var containerBuilder = new ContainerBuilder();

            var executingAssembly = Assembly.GetExecutingAssembly();

            containerBuilder.RegisterControllers(executingAssembly);
            containerBuilder.RegisterAssemblyModules(executingAssembly);

            var container = containerBuilder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}