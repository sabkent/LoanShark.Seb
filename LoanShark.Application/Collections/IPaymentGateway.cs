using System;

namespace LoanShark.Application.Collections
{
    public interface IPaymentGateway
    {
        TakePaymentResponse TakePayment(TakePaymentRequest creditPaymentRequest);
    }
}
