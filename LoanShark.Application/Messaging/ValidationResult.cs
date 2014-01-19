using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Application.Messaging
{
    public sealed class ValidationResult
    {
        public ValidationResult(string key, string message)
        {
            Key = key;
            Message = message;
        }
        public string Key { get; private set; }
        public string Message { get; private set; }
    }
}
