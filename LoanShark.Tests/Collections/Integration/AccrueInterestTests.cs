using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using LoanShark.Core.Collections.Commands;
using LoanShark.Messaging;
using NUnit.Framework;

namespace LoanShark.Tests.Collections.Integration
{
    [TestFixture]
    public class AccrueInterestTests
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
        public void AcrueInterest()
        {
            var commandDispather = _container.Resolve<ICommandDispatcher>();

            commandDispather.Send(new ApplyInterestRate(Guid.NewGuid()));
        }
    }
}
