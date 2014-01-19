using LoanShark.Application.Messaging;
using LoanShark.Application.Origination.Events;
using LoanShark.Core;
using LoanShark.Core.Collections.Projections;
using System;

namespace LoanShark.Application.Collections.EventSubscribers
{
    public sealed class LoanApplicationAcceptedPaymentRecord : ISubscribeToEvent<LoanApplicationAccepted>
    {
        private readonly IReadModelRepository _readModelRepository;

        public LoanApplicationAcceptedPaymentRecord(IReadModelRepository readModelRepository)
        {
            _readModelRepository = readModelRepository;
        }

        public void Notify(LoanApplicationAccepted @event)
        {
            var debt = new Debt {Id = @event.ApplicationId, Amount = @event.Amount, Due = TimeSource.Now};
            _readModelRepository.Save(debt);
        }
    }
}
