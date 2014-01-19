using System.Collections.Generic;
using LoanShark.Application.Messaging;
using LoanShark.Core.Origination.Commands;

namespace LoanShark.Application.Origination.CommandValidators
{
    public sealed class ApplyForLoanInputValidator : IValidateCommand<ApplyForLoan>
    {
        public IEnumerable<ValidationResult> Validate(ApplyForLoan command)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();



            return validationResults;
        }

    }
}
