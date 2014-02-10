using Autofac;
using LoanShark.Application.Collections.CommandHandlers;
using LoanShark.Application.Collections.EventSubscribers;
using LoanShark.Application.Messaging;
using LoanShark.Application.Origination.Events;
using LoanShark.Core.Collections.Commands;
using LoanShark.Messaging;

namespace LoanShark.Application.Collections
{
    public sealed class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterEventSubscribers(builder);
            RegisterCommandHandlers(builder);
        }

        private void RegisterEventSubscribers(ContainerBuilder builder)
        {
            builder.RegisterType<LoanApplicationAcceptedPaymentRecord>()
                .As<ISubscribeToEvent<LoanApplicationAccepted>>();
        }

        private void RegisterCommandHandlers(ContainerBuilder builder)
        {
            builder.RegisterType<CollectDebtHandler>().As<IHandleCommand<CollectDebt>>();
        }
    }
}
