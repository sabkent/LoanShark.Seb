using Autofac;
using LoanShark.Application;
using LoanShark.Application.Collections;
using LoanShark.Application.Collections.CommandHandlers;
using LoanShark.Core;
using LoanShark.Infrastructure.Collections;

namespace LoanShark.Infrastructure
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlEventStore>().As<IEventStore>();
            builder.RegisterType<EventSourcedRepository>().As<IRepository>();

            builder.RegisterType<MongoDbReadModelRepository>().As<IReadModelRepository>();

            builder.RegisterType<PaypalPaymentGateway>().As<IPaymentGateway>();
            builder.RegisterType<CollectionProcessor>().As<ICollectionProcessor>();

            builder.RegisterType<MongoProjectionMapping>().As<IBootstrapTask>();
        }
    }
}
