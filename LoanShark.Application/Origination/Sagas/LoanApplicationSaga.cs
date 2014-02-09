using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanShark.Application.Messaging;
using LoanShark.Application.Origination.Events;
using LoanShark.Messaging;

namespace LoanShark.Application.Origination.Sagas
{
    public class LoanApplicationSaga : ISubscribeToEvent<LoanApplicationSubmitted>
    {
        public void Notify(LoanApplicationSubmitted @event)
        {
            throw new NotImplementedException();
        }
    }
}
