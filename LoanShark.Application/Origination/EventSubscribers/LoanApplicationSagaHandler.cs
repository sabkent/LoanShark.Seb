using System;
using LoanShark.Application.Origination.Events;
using LoanShark.Messaging;

namespace LoanShark.Application.Origination.EventSubscribers
{
    public sealed class LoanApplicationSagaHandler : 
        ISubscribeToEvent<LoanApplicationSubmitted>,
        ISubscribeToEvent<LoanApplicationAccepted>
    {
        public void Notify(LoanApplicationSubmitted @event)
        {
            throw new NotImplementedException();
        }

        public void Notify(LoanApplicationAccepted @event)
        {
            throw new NotImplementedException();
        }
    }
}
