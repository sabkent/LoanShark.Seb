using LoanShark.Application.Messaging;
using LoanShark.Application.Origination.Events;
using LoanShark.Core;
using LoanShark.Core.Collections.Data;
using LoanShark.Core.Collections.Domain;
using LoanShark.Core.Collections.Projections;
using System;
using LoanShark.Messaging;

namespace LoanShark.Application.Collections.EventSubscribers
{
    public sealed class LoanApplicationAcceptedPaymentRecord : ISubscribeToEvent<LoanApplicationAccepted>
    {        
        private readonly IDebtRepository _debtRepository;
        private readonly IEventPublisher _eventPublisher;

        public LoanApplicationAcceptedPaymentRecord(IDebtRepository debtRepository, IEventPublisher eventPublisher)
        {
            _debtRepository = debtRepository;
            _eventPublisher = eventPublisher;
        }

        public void Notify(LoanApplicationAccepted loanApplicationAccepted)
        {
            var debt = new Debt(loanApplicationAccepted.ApplicationId);

            var events = debt.Incur(loanApplicationAccepted.Amount);
            //_debtRepository.Save(debt);

            foreach (var @event in events)            
                _eventPublisher.Publish(@event);
        }
    }
}
