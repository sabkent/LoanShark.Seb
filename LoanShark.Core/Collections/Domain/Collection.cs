using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LoanShark.Core.Collections.Domain.Events;

namespace LoanShark.Core.Collections.Domain
{
    public class DebtCollection : Aggregate
    {
        private List<OutstandingDebt> _outstandingDebts;
        private List<CollectionAttempt> _collectionAttempts;

        public DebtCollection(Guid id)
        {
            Apply(new DebtCollectionCreated(id));
        }

        public void AddOutstandingDebts(List<OutstandingDebt> outstandingDebts)
        {
            foreach(var outstandingDebt in outstandingDebts)
                Apply(new DebtAddedToCollection(outstandingDebt));
        }

        public void AddCollectionAttempts(List<CollectionAttempt> collectionAttempts)
        {
            foreach(var collectionAttempt in collectionAttempts)
                Apply(new DebtCollectionAttempted(collectionAttempt));
        }

        private void ApplyEvent(DebtCollectionCreated debtCollectionCreated)
        {
            Id = debtCollectionCreated.Id;
            _outstandingDebts = new List<OutstandingDebt>();
            _collectionAttempts = new List<CollectionAttempt>();
        }

        private void ApplyEvent(DebtAddedToCollection debtAddedToCollection)
        {
            _outstandingDebts.Add(debtAddedToCollection.OutstandingDebt);
        }

        private void ApplyEvent(DebtCollectionAttempted debtCollectionAttempted)
        {
            _collectionAttempts.Add(debtCollectionAttempted.Attempt);
        }

        public List<OutstandingDebt> GetRemaining()
        {
            var successfullCollections = _collectionAttempts.Where(attempt => attempt.Success).Select(attempt => attempt.Id);
            return _outstandingDebts.Where(debt => successfullCollections.Contains(debt.Id) == false).ToList();           
        }
    }

    public class CollectionRun
    {
        public List<CollectionAttempt> CollectionAttempts { get; set; }
    }

    public class OutstandingDebt
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
    }

    public class CollectionAttempt
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
    }

    public class MatureDebt : Aggregate
    {
        private DateTime _due;
        private decimal _amount;
        private List<CollectionAttempt> _collectionAttempts;

        public MatureDebt(Guid id, DateTime due, decimal amount)
        {
            Apply(new DebtMatured(id, due, amount));
        }

        public IEnumerable<IEvent> AddCollectionAttempt(CollectionAttempt collectionAttempt)
        {
            //if outsstanding baalnce is null then this is invalid

            //if collected amount clears balance then apply event de=bt clear, this event is returned too to be broadcast
            
            return new List<IEvent>();
        }

        public bool CanAttemptCollection()
        {
            //check history. off days etc etc
            return true;
        }

        private void ApplyEvent(DebtMatured debtMatured)
        {
            Id = debtMatured.Id;
            _due = debtMatured.Due;
            _amount = debtMatured.Amount;
        }
    }

    public sealed class DebtMatured : IEvent
    {
        public DebtMatured(Guid id, DateTime due, decimal amount)
        {
            Id = id;
            Due = due;
            Amount = amount;
        }

        public Guid Id { get; private set; }
        public DateTime Due { get; private set; }
        public decimal Amount { get; private set; }
    }
}