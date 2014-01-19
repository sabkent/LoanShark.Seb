using System;
using System.Collections.Generic;
namespace LoanShark.Core.Collections.Domain.Events
{
    internal sealed class DebtCollectionCreated : IEvent
    {
        private Guid _id;

        public DebtCollectionCreated(Guid id)
        {
            _id = id;
        }

        public Guid Id { get { return _id; } }
    }
}
