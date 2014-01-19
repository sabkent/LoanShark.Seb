using EasyNetQ;
using LoanShark.Application.Messaging;
using LoanShark.Core;

namespace LoanShark.Messaging.EasyNetQ
{
    public class EasyNetQMessageBus : ICommandDispatcher
    {
        private IBus _bus;

        public EasyNetQMessageBus(IBus bus)
        {
            _bus = bus;
        }

        public void Send<T>(T command) where T : class,  ICommand
        {
            _bus.Publish(command);
        }
    }
}
