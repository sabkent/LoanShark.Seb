using System;

namespace LoanShark.Core
{
    public interface ICommand
    {
        Guid Id { get; } //id so ppl can ask how is the progress of async command 1. alt: use ICommandResult
    }
}
