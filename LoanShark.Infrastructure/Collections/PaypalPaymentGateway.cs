using System.Threading;
using LoanShark.Application.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Infrastructure.Collections
{
    public sealed class PaypalPaymentGateway : IPaymentGateway
    {
        public TakePaymentResponse TakePayment(TakePaymentRequest creditPaymentRequest)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            return new TakePaymentResponse
            {
                Succeded = DateTime.Now.Millisecond%2 == 0
            };
        }
    }
}
