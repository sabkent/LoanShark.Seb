using LoanShark.Messaging;
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
            var bus = new OctoBus();

            bus.Publish(new MyMessage());
        }

        public class MyMessage
        {
            
        }
    }
}
