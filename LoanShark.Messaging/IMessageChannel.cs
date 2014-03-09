using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Messaging
{
    interface IMessageChannel : IDisposable
    {
        void Send(byte[] data);
    }
}
