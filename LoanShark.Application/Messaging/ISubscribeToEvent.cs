using System;

namespace LoanShark.Application.Messaging
{
    public interface ISubscribeToEvent<T>
    {
        void Notify(T @event);
    }
}
