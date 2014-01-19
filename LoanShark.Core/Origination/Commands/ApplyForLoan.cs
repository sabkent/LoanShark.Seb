using System;

namespace LoanShark.Core.Origination.Commands
{
    [Serializable]
    public class ApplyForLoan : ICommand
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }

        public string FirstName { get; set; }
    }
}
