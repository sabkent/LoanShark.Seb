using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanShark.Core;

namespace LoanShark.Application.Messaging
{
    public interface IValidateCommand<T>
    {
        IEnumerable<ValidationResult> Validate(T command);
    }
}
