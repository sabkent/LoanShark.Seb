using System;
namespace LoanShark.Core.Collections.Commands
{
    public sealed class IncurDebt : ICommand
    {
        public IncurDebt(Guid id, decimal amount)
        {
            Id = id;
            Amount = amount;
        }
        public Guid Id { get; private set; }
        
        public decimal Amount { get; private set; }
    }
}
