using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Messaging
{
    public interface IMessageBus
    {
        void Publish<T>(T message);

        ICallback Send<T>(T message);
    }
}
