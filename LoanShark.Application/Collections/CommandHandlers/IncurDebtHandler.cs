using System;
using LoanShark.Core.Collections.Commands;
using LoanShark.Core.Collections.Data;
using LoanShark.Core.Collections.Domain;
using LoanShark.Messaging;

namespace LoanShark.Application.Collections.CommandHandlers
{
    public sealed class IncurDebtHandler : IHandleCommand<IncurDebt>
    {
        private readonly IDebtRepository _debtRepository;

        public IncurDebtHandler(IDebtRepository debtRepository)
        {
            _debtRepository = debtRepository;
        }

        public void Handle(IncurDebt command)
        {
            var debt = new Debt(command.Id);
            
            var events = debt.Incur(command.Amount);
            
            _debtRepository.Save(debt);
        }
    }
}
