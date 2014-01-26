using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanShark.Core.Collections.Domain.Events;

namespace LoanShark.Core.Collections.Domain
{
    /// <summary>
    /// When a loan is approved a debt will be created, this will also then create a OutstandingDebt in read model
    /// </summary>
    public class Debt : Aggregate
    {
        private decimal _amount;
        
        public Debt(Guid id)
        {
            Id = id;
        }

        //this is here just so we can return the event, to be published... instead of have the event created in ctor... tis a compremise
        public IEnumerable<IEvent> Incur(decimal amount)
        {
            var debtIncurred = new DebtIncurred(amount);

            Apply(debtIncurred);

            return new[] {debtIncurred};
        }

        private void ApplyEvent(DebtIncurred debtIncurred)
        {
            _amount = debtIncurred.Amount;
        }
    }
}
