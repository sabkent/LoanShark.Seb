using LoanShark.Messaging;
using LoanShark.Messaging.OctoBus;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Tests.Messaging
{
    [TestFixture]
    public class OctoBusTests
    {
        [Test]
        public void PublishMessage()
        {
            new MessageBroker();
            
            var messageBus = new MessageBus();

            var callback = messageBus.Send(new MyMessage { FirstName = "seb", Amount = 100m });

        }

        public class MyMessage
        {
            public string FirstName { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
