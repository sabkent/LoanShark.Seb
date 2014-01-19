using System;

namespace LoanShark.Application.Collections
{
    public class TakePaymentRequest
    {
        public TakePaymentRequest(decimal amount)
        {
            Amount = amount;
        }
        public decimal Amount { get; private set; }
    }
}
