using LoanShark.Core;
using System;
using System.Linq;

namespace LoanShark.Infrastructure
{
    public class EventSourcedRepository : IRepository
    {
        private readonly IEventStore _eventStore;
        
        public EventSourcedRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public T GetById<T>(Guid id) where T : Aggregate
        {
            var events = _eventStore.LoadEvents(id);
            var aggregate = Activator.CreateInstance<T>();
            
            aggregate.LoadFromHistory(events);
            return aggregate;
        }

        public void Save(Aggregate aggregate)
        {
            var events = aggregate.GetUncommittedChanges().ToList();
            var currentVersion = aggregate.Version;
            var initialVersion = currentVersion - events.Count;

            _eventStore.StoreEvents(aggregate.Id, events, initialVersion);
            aggregate.ClearEvents();
        }
    }
}
