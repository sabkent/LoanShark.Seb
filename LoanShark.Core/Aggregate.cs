using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace LoanShark.Core
{
    public abstract class Aggregate
    {
        private readonly List<IEvent> _uncommittedEvents = new List<IEvent>();

        public Guid Id { get; protected set; }
        public long Version { get; private set; }

        public void Apply<T>(T @event) where T : IEvent
        {
            _uncommittedEvents.Add(@event);
            Version++;

            AggregateUpdater.Update(this, @event);
        }

        public void LoadFromHistory(IEnumerable<IEvent> events)
        {
            foreach (var @event in events)
            {
                AggregateUpdater.Update(this, @event);
                Version++;
            }
        }

        public IEnumerable<IEvent> GetUncommittedChanges()
        {
            return _uncommittedEvents;
        }

        public void ClearEvents()
        {
            _uncommittedEvents.Clear();
        }

        private static class AggregateUpdater
        {
            private static readonly ConcurrentDictionary<Tuple<Type, Type>, Action<Aggregate, object>> cache = new ConcurrentDictionary<Tuple<Type, Type>, Action<Aggregate, object>>();

            public static void Update(Aggregate instance, object @event)
            {
                var tuple = new Tuple<Type, Type>(instance.GetType(), @event.GetType());
                var action = cache.GetOrAdd(tuple, ActionFactory);
                action(instance, @event);
            }

            private static Action<Aggregate, object> ActionFactory(Tuple<Type, Type> key)
            {
                var eventType = key.Item2;
                var aggregateType = key.Item1;

                const string methodName = "ApplyEvent";
                var method = aggregateType.GetMethods(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    .SingleOrDefault(x => x.Name == methodName && x.GetParameters().Single().ParameterType.IsAssignableFrom(eventType));

                if (method == null)
                    return (x, y) => { };

                return (instance, @event) => method.Invoke(instance, new[] { @event });
            }
        }
    }
}
