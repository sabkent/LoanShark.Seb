using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanShark.Core;
using LoanShark.Core.Collections.Commands;
using LoanShark.Core.Collections.Data;
using LoanShark.Core.Collections.Domain;
using LoanShark.Messaging;

namespace LoanShark.Application.Collections.CommandHandlers
{
    public sealed class ApplyInterestRateHandler : IHandleCommand<ApplyInterestRate>
    {
        private readonly IReadModelRepository _readModelRepository;
        private readonly IDebtRepository _repository;
        private readonly IEventPublisher _eventPublisher;

        public ApplyInterestRateHandler(IReadModelRepository readModelRepository, IDebtRepository repository, IEventPublisher eventPublisher)
        {
            _readModelRepository = readModelRepository;
            _repository = repository;
            _eventPublisher = eventPublisher;
        }

        public void Handle(ApplyInterestRate command)
        {
            var outstandingDebts = _readModelRepository.GetAll<OutstandingDebt>(debt => debt.Amount > 0);

            foreach (var outstandingDebt in outstandingDebts)
            {
                var debt = _repository.GetById<Debt>(outstandingDebt.Id);

                if (debt != null)
                {
                    var events = debt.AccrueInterest();
                    _eventPublisher.Publish(events);
                }
            }

            //load all the projects into memory that represent this query... 
            //send the commands for each projection back onto the bus
        }
    }
}
