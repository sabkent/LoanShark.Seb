using System;

namespace LoanShark.Core.Collections.Domain.Events
{
    public sealed class DebtCollectionAttempted : IEvent
    {
        private readonly CollectionAttempt _collectionAttempt;

        public DebtCollectionAttempted(CollectionAttempt collectionAttempt)
        {
            _collectionAttempt = collectionAttempt;
        }

        public CollectionAttempt Attempt
        {
            get { return _collectionAttempt; }
        }
    }
}
