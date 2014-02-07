using Autofac;
using EasyNetQ;
using LoanShark.Application;
using LoanShark.Application.Messaging;
using LoanShark.Application.Origination.Events;
using LoanShark.Core.Origination.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LoanShark.Messaging.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().StartEndPoint();
            Console.ReadKey();
        }

        private IBus _bus;
        private Autofac.IContainer _container;

        public void StartEndPoint()
        {
            

            SetupContainer();
            BootStrap();
            SetupSubscriptions();
        }

        private void SetupContainer()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var assemblies = Directory.GetFiles(path).Where(fileName => Path.GetFileName(fileName).StartsWith("LoanShark") && Path.GetExtension(fileName).Equals(".dll")).ToList();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyModules(assemblies.Select(Assembly.LoadFile).ToArray());

            _container = containerBuilder.Build();
        }

        private void BootStrap()
        {
            foreach (var bootstrapTask in _container.Resolve<IEnumerable<IBootstrapTask>>())
                bootstrapTask.Run();
        }

        private void SetupSubscriptions()
        {
            string subscriptionId = "LoanShark.Messaging.Host";
            _bus = _container.Resolve<IBus>();

            _bus.Subscribe<ApplyForLoan>(subscriptionId, applyForLoan =>
            {
                var handler = _container.Resolve<IHandleCommand<ApplyForLoan>>();
                if (handler != null)
                    handler.Handle(applyForLoan);
            });

            _bus.Subscribe<LoanApplicationAccepted>(subscriptionId, loanApplicationAccepted =>
            {
                var subscribers = _container.Resolve<IEnumerable<ISubscribeToEvent<LoanApplicationAccepted>>>();
                subscribers.ToList().ForEach(subscriber => subscriber.Notify(loanApplicationAccepted));
            });
        }
    }
}
