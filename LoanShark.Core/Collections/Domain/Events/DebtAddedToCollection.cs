using System;

namespace LoanShark.Core.Collections.Domain.Events
{
    public class DebtAddedToCollection : IEvent
    {
        public DebtAddedToCollection(OutstandingDebt outstandingDebt)
        {
            OutstandingDebt = outstandingDebt;
        }
        public OutstandingDebt OutstandingDebt { get; private set; }
    }
}
