using System;
using System.Collections;
using System.Collections.Generic;
using LoanShark.Core.Origination.Domain.Events;

namespace LoanShark.Core.Origination.Domain
{
    public class LoanApplication : Aggregate
    {
        public LoanApplication(Guid id)
        {
            Apply(new ApplicationCreated(id));
        }

        public void Defer()
        {
            //if(loan.sts != deferr)

            //apply(LoanWasDefereredEvent)
        }

        public IEnumerable<IEvent> ComplexProcess()
        {
            return new List<IEvent>();



        }

        public Applicant Applicant { get; set; }

        private void ApplyEvent(ApplicationCreated applicationCreated)
        {
            Id = applicationCreated.Id;
        }

        public bool IsAccepted()
        {
            return false;
        }
    }
}
