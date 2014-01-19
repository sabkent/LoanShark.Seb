using System;

namespace LoanShark.Application.Messaging
{
    public interface IHandleCommand<T>
    {
        void Handle(T command);
    }
}
