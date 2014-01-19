using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanShark.Core.Collections.Domain;

namespace LoanShark.Application.Collections.CommandHandlers
{
    public sealed class CollectionProcessor : ICollectionProcessor
    {
        private readonly IPaymentGateway _paymentGateway;

        public CollectionProcessor(IPaymentGateway paymentGateway)
        {
            _paymentGateway = paymentGateway;
        }

        public IEnumerable<CollectionAttempt> Process(IEnumerable<OutstandingDebt> outstandingDebts)
        {
            var collectionAttempts = new ConcurrentQueue<CollectionAttempt>();
            Parallel.ForEach(outstandingDebts, debt =>
            {
                var creditPaymentResponse = _paymentGateway.TakePayment(new TakePaymentRequest(debt.Amount));
                var collectionAttempt = new CollectionAttempt
                {
                    Id = debt.Id,
                    Success = creditPaymentResponse.Succeded
                };
                collectionAttempts.Enqueue(collectionAttempt);
            });
            return collectionAttempts.ToList();
        }
    }
}