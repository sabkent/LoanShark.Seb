using Autofac;
using Autofac.Core;
using LoanShark.Application.Messaging;
using LoanShark.Application.Origination.CommandHandlers;
using LoanShark.Application.Origination.Events;
using LoanShark.Application.Origination.EventSubscribers;
using LoanShark.Core;
using LoanShark.Core.Origination.Commands;
using LoanShark.Core.Origination.Commands.Validators;

namespace LoanShark.Application
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplyForLoanHandler>().As<IHandleCommand<ApplyForLoan>>();
            builder.RegisterType<LoanApplicationReadModelDenormalizer>()
                .As<ISubscribeToEvent<LoanApplicationAccepted>>();
            builder.RegisterType<LoanApplicationCompleteSignaler>().As<ISubscribeToEvent<LoanApplicationAccepted>>();

            RegisterCommandValidators(builder);
        }

        private void RegisterCommandValidators(ContainerBuilder builder)
        {
            builder.RegisterType<CommandValidation>().As<ICommandValidation>();

            builder.RegisterType<ApplyForLoanInputValidator>().As<IValidateCommand<ApplyForLoan>>();
        }
    }
}
