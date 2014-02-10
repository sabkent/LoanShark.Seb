using LoanShark.Core;

namespace LoanShark.Messaging
{
    public interface ICommandDispatcher
    {
        void Send<T>(T command) where T : class, ICommand;
    }
}
