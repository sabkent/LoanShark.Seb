namespace LoanShark.Messaging
{
    public interface IHandleCommand<T>
    {
        void Handle(T command);
    }
}
