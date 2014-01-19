using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanShark.Application.Messaging;

namespace LoanShark.Core.Origination.Commands.Validators
{
    public sealed class ApplyForLoanDuplicateValidator : IValidateCommand<ApplyForLoan>
    {
        public IEnumerable<ValidationResult> Validate(ApplyForLoan command)
        {
            return new List<ValidationResult>();
        }
    }
}
