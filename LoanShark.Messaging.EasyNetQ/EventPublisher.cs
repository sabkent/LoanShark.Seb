using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanShark.Application.Messaging;
using EasyNetQ;

namespace LoanShark.Messaging.EasyNetQ
{
    public sealed class EventPublisher : IEventPublisher
    {
        private readonly IBus _bus;
        public EventPublisher(IBus bus)
        {
            _bus = bus;
        }

        public void Publish<T>(T @event) where T:class
        {
            _bus.Publish(@event);
        }
    }
}
