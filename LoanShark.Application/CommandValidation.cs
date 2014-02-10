using System.Collections.Generic;
using System.Linq;
using LoanShark.Application.Messaging;
using Autofac;
using LoanShark.Core;

namespace LoanShark.Application
{
    public sealed class CommandValidation : ICommandValidation
    {
        private readonly IComponentContext _componentContext;
        public CommandValidation(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }
          
        public IEnumerable<ValidationResult> Validate<T>(T command)
        {
            var validators = _componentContext.Resolve<IEnumerable<IValidateCommand<T>>>();
            return validators.AsParallel().SelectMany(validator => validator.Validate(command));
        }
    }
}
