using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Messaging.OctoBus
{
    class SubscriberRegistry : ISubscriberRegistry
    {
        
        public void Subscribe<T>(IHandleMessage<T> handler)
        {
            throw new NotImplementedException();
        }
    }
}
