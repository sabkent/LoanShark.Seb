using LoanShark.Application.Origination.Events;
using LoanShark.Core.Collections.Commands;
using LoanShark.Messaging;

namespace LoanShark.Application.Collections.EventSubscribers
{
    public sealed class LoanApplicationAcceptedPaymentRecord : ISubscribeToEvent<LoanApplicationAccepted> //Collections BC maps to Origination
    {     
        private readonly ICommandDispatcher _commandDispatcher;

        public LoanApplicationAcceptedPaymentRecord(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public void Notify(LoanApplicationAccepted loanApplicationAccepted)
        {
            var incurDebt = new IncurDebt(loanApplicationAccepted.ApplicantId, loanApplicationAccepted.Amount);
            _commandDispatcher.Send(incurDebt);
        }
    }
}
