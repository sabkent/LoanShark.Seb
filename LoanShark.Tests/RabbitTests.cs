using Autofac;
using LoanShark.Application.Messaging;
using LoanShark.Application.Origination.CommandHandlers;
using LoanShark.Core.Origination.Commands;
using LoanShark.Messaging;
using LoanShark.Messaging.EasyNetQ;
using LoanShark.Messaging.RabbitMQ;
using NUnit.Framework;

namespace LoanShark.Tests
{
    [TestFixture]
    public class RabbitTests
    {
        private IContainer _container;

        [SetUp]
        public void Setup()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<Consumer>().As<IMessageConsumer>();

            builder.RegisterType<ApplyForLoanHandler>().As<IHandleCommand<ApplyForLoan>>();

            _container = builder.Build();
        }


        //[Test]
        //public void Test()
        //{
        //    var publisher = new Publisher();

        //    publisher.Send(new ApplyForLoan());
        //}

        //[Test]
        //public void Consume()
        //{
        //    var consumer = _container.Resolve<IMessageConsumer>();
        //    consumer.Start();
        //}


    }
}
