using LoanShark.Application;
using LoanShark.Application.Collections;
using LoanShark.Application.Collections.CommandHandlers;
using LoanShark.Core;
using LoanShark.Core.Collections.Commands;
using LoanShark.Core.Collections.Projections;
using LoanShark.Infrastructure.Collections;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;

namespace LoanShark.Tests.Collections.Integration.Application.CommandHandlers
{
    [TestFixture]
    public class CollectDebtHandlerTests
    {
        [Test]
        public void Test()
        {
            var count = 10;
            var debts = Enumerable.Range(1, count).ToList().ConvertAll(index => new OutstandingDebt { Id = Guid.NewGuid(), Amount = 150 });
            
            var readModelRepository = new Mock<IReadModelRepository>();
            var paymentGateway = new Mock<IPaymentGateway>();
            readModelRepository.Setup(repository => repository.GetAll<OutstandingDebt>(debt => debt.Due.Date == TimeSource.Now.Date))
                .Returns(debts);

            var collectDebtHandler = new CollectDebtHandler(readModelRepository.Object, paymentGateway.Object);

            //var commandHandler = new CollectDebtHandler(readModelRepository.Object, new CollectionProcessor(new PaypalPaymentGateway()));

            var stopWatch = Stopwatch.StartNew();
            collectDebtHandler.Handle(new CollectDebt());
            stopWatch.Stop();
            Console.WriteLine("Handle collect {0} debts took {1}", count, stopWatch.Elapsed);
        }
    }
}
