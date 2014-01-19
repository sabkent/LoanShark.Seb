using LoanShark.Application.Messaging;
using LoanShark.Core;
using LoanShark.Core.Collections.Commands;
using LoanShark.Core.Collections.Domain;
using LoanShark.Core.Collections.Projections;
using System;
using System.Linq;

namespace LoanShark.Application.Collections.CommandHandlers
{
    public sealed class CollectDebtHandler : IHandleCommand<CollectDebt>
    {
        private readonly IReadModelRepository _readModelRepository;
        private readonly ICollectionProcessor _collectionProcessor;
        private readonly IPaymentGateway _paymentGateway;
        private readonly IRepository _repository;
        private readonly IEventPublisher _eventPublisher;

        public CollectDebtHandler(IReadModelRepository readModelRepository, IPaymentGateway paymentGateway)
        {
            _readModelRepository = readModelRepository;
            _paymentGateway = paymentGateway;
        }

        public void Handle(CollectDebt applyForLoan)
        {
            var dueDebts = _readModelRepository.GetAll<Debt>(debt => debt.Due.Date == TimeSource.Now.Date);

            foreach (var dueDebt in dueDebts)
            {
                var matureDebt = new MatureDebt(dueDebt.Id, dueDebt.Due, dueDebt.Amount);
                var takePaymentRequest = new TakePaymentRequest(dueDebt.Amount);
                var takePaymentResponse = _paymentGateway.TakePayment(takePaymentRequest);
                var events = matureDebt.AddCollectionAttempt(new CollectionAttempt{Id = dueDebt.Id, Success = takePaymentResponse.Succeded});
                _repository.Save(matureDebt);

                events.ToList().ForEach(e => _eventPublisher.Publish(e));
            }
        }

        public void _Handle(CollectDebt applyForLoan)
        {
            var dueDebts = _readModelRepository.GetAll<Debt>(debt => debt.Due.Date == TimeSource.Now.Date);

            var outstandingDebts =
                dueDebts.ToList().ConvertAll(debt => new OutstandingDebt {Id = debt.Id, Amount = debt.Amount});

            var debtCollection = new DebtCollection(Guid.NewGuid());

            debtCollection.AddOutstandingDebts(outstandingDebts);
            
            for (var attempCount = 0; attempCount < 3; attempCount++)
            {
                var remainingDebts = debtCollection.GetRemaining();
                    
                if (remainingDebts.Count == 0) break;
                var collectionAttempts = _collectionProcessor.Process(remainingDebts);
                
                debtCollection.AddCollectionAttempts(collectionAttempts.ToList());
            }
        }

        
    }
}