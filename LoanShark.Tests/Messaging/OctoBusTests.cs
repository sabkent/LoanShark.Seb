using Autofac;
using LoanShark.Core.Origination.Commands;
using LoanShark.Messaging;
using LoanShark.Messaging.RabbitMQ;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Tests.Messaging
{
    [TestFixture]
    public class OctoBusTests
    {
        [Test]
        public void PublishMessage()
        {
            new Publisher().Send(new ApplyForLoan());
        }

        [Test]
        public void Test()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            
            var container = containerBuilder.Build();

            new Consumer(container).Start();
        }

        public class MyMessage
        {
            
        }
    }
}
