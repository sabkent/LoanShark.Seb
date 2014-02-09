namespace LoanShark.Messaging
{
    public interface ISubscribeToEvent<T>
    {
        void Notify(T @event);
    }
}
