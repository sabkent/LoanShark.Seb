using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanShark.Application.Messaging;

namespace LoanShark.Core.Origination.Commands.Validators
{
    public sealed class ApplyForLoanInputValidator : IValidateCommand<ApplyForLoan>
    {
        public IEnumerable<ValidationResult> Validate(ApplyForLoan command)
        {
            if(String.IsNullOrWhiteSpace(command.FirstName))
                yield return new ValidationResult("FirstName", "First name is required"); //refer to key without string?
            
        }
    }
}
