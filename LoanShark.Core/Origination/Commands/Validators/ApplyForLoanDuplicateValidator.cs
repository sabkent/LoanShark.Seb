using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanShark.Application.Messaging;
using LoanShark.Core.Origination.Projections;

namespace LoanShark.Core.Origination.Commands.Validators
{
    public sealed class ApplyForLoanDuplicateValidator : IValidateCommand<ApplyForLoan>
    {
        private readonly IReadModelRepository _readModelRepository;

        public ApplyForLoanDuplicateValidator(IReadModelRepository readModelRepository)
        {
            _readModelRepository = readModelRepository;
        }

        public IEnumerable<ValidationResult> Validate(ApplyForLoan command)
        {
            var acceptedLoans = _readModelRepository.GetAll<AcceptedLoan>(loan => loan.FirstName == command.FirstName);
            if(acceptedLoans.Count() >3)
                yield return new ValidationResult(String.Empty, "There are over 3 matching accounts");
        }
    }
}
