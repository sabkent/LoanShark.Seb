using LoanShark.Application.Messaging;
using LoanShark.Application.Origination.Events;
using LoanShark.Core;
using LoanShark.Core.Origination.Projections;
using System;
using LoanShark.Messaging;

namespace LoanShark.Application.Origination.EventSubscribers
{
    public sealed class LoanApplicationReadModelDenormalizer : ISubscribeToEvent<LoanApplicationAccepted>
    {
        private readonly IReadModelRepository _readModelRepository;
        public LoanApplicationReadModelDenormalizer(IReadModelRepository readModelRepository)
        {
            _readModelRepository = readModelRepository;
        }

        public void Notify(LoanApplicationAccepted @event)
        {
            _readModelRepository.Save(new AcceptedLoan{ApplicationId = @event.ApplicationId, Requested = DateTime.Now, FirstName = "seb"});
        }
    }
}
