using System.Collections.Generic;

namespace LoanShark.Core
{
    public interface ICommandValidation
    {
        IEnumerable<ValidationResult> Validate<T>(T command);
    }
}
