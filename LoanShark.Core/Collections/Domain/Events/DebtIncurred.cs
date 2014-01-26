using System;

namespace LoanShark.Core.Collections.Domain.Events
{
    public class DebtIncurred : IEvent
    {
        public DebtIncurred(decimal amount)
        {
            Amount = amount;
        }
        public decimal Amount { get; private set; }
    }
}
