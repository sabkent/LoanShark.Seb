using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Messaging
{
    public interface IHandleMessage<T>
    {
        void Handle(T message);
    }
}
