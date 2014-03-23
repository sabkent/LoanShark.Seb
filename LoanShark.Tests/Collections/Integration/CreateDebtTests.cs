using Autofac;
using Autofac.Core;
using LoanShark.Application.Messaging;
using LoanShark.Core.Collections.Domain.Events;
using LoanShark.Messaging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Tests.Collections.Integration
{
    [TestFixture]
    public class CreateDebtTests
    {
        private IContainer _container;

        [SetUp]
        public void Setup()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new LoanShark.Application.ContainerModule());
            containerBuilder.RegisterModule(new LoanShark.Application.Collections.ContainerModule());
            containerBuilder.RegisterModule(new LoanShark.Infrastructure.ContainerModule());
            containerBuilder.RegisterModule(new LoanShark.Messaging.EasyNetQ.ContainerModule());
            _container = containerBuilder.Build();
        }


        [Test]
        public void DebtIncurredEvent_OutstandingDebtCreatedInReadModel()
        {
            var eventPublisher = _container.Resolve<IEventPublisher>();

            eventPublisher.Publish(new DebtIncurred(100));
            
        }
    }
}
