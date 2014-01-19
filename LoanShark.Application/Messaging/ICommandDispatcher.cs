using System;
using LoanShark.Core;

namespace LoanShark.Application.Messaging
{
    public interface ICommandDispatcher
    {
        void Send<T>(T command) where T : class, ICommand;
    }
}
