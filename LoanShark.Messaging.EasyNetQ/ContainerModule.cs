using Autofac;
using EasyNetQ;
using LoanShark.Application.Messaging;
using System.Configuration;

namespace LoanShark.Messaging.EasyNetQ
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EasyNetQMessageBus>().As<ICommandDispatcher>();
            builder.RegisterType<EventPublisher>().As<IEventPublisher>().InstancePerLifetimeScope();
            builder.Register(c => RabbitHutch.CreateBus(ConfigurationManager.AppSettings["RabbitMQ:Connection"])).As<IBus>().InstancePerLifetimeScope();
        }
    }
}
