using System.Collections.Generic;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Autofac.Integration.WebApi;
using LoanShark.Application;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace LoanShark.Origination.Site.App_Start
{
    public static class ContainerConfig
    {
        public static void Configure()
        {
            var containerBuilder = new ContainerBuilder();

            var executingAssembly = Assembly.GetExecutingAssembly();

            containerBuilder.RegisterControllers(executingAssembly);
            containerBuilder.RegisterApiControllers(executingAssembly);
            containerBuilder.RegisterAssemblyModules(executingAssembly);

            var path = Path.GetDirectoryName(new Uri(executingAssembly.GetName().CodeBase).LocalPath);
            var assemblyNames = Directory.GetFiles(path).Where(fileName => Path.GetFileName(fileName).StartsWith("LoanShark") && Path.GetExtension(fileName).Equals(".dll")).ToList();

            //this stopped working :(
            //containerBuilder.RegisterAssemblyModules(assemblyNames.Select(Assembly.LoadFile).ToArray());
            containerBuilder.RegisterModule(new LoanShark.Application.ContainerModule());
            containerBuilder.RegisterModule(new LoanShark.Application.Collections.ContainerModule());
            containerBuilder.RegisterModule(new LoanShark.Infrastructure.ContainerModule());
            containerBuilder.RegisterModule(new LoanShark.Messaging.EasyNetQ.ContainerModule());
            


            var container = containerBuilder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            container.Resolve<IEnumerable<IBootstrapTask>>().ToList().ForEach(bootstrapTask => bootstrapTask.Run());

            containerBuilder.Register(context => GlobalHost.ConnectionManager).As<IConnectionManager>();
        }
    }
}