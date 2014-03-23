using System;
using System.Collections.Generic;
using System.Linq;
using LoanShark.Core.Collections.Domain.Events;

namespace LoanShark.Core.Collections.Domain
{
    /// <summary>
    /// When a loan is approved a debt will be created, this will also then create a OutstandingDebt in read model
    /// </summary>
    public class Debt : Aggregate
    {
        private decimal _amount;
        private IList<Interest> _interestAccrued = new List<Interest>();
        
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

        public IEnumerable<IEvent> AccrueInterest()
        {
           

            var interestAccrued = new InterestAccrued();

            Apply(interestAccrued);

            return new[] {interestAccrued};
        }

        private void ApplyEvent(DebtIncurred debtIncurred)
        {
            _amount = debtIncurred.Amount;
        }

        private void ApplyEvent(InterestAccrued interestAccrued)
        {
            _amount += interestAccrued.Amount;

            _interestAccrued.Add(new Interest());
        }
    }
}
