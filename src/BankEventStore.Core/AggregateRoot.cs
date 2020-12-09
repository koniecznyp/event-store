using BankEventStore.Core.Events;
using System;
using System.Collections.Generic;

namespace BankEventStore.Core
{
    public abstract class AggregateRoot
    {
        private readonly List<IEvent> events;

        public Guid Id { get; protected set; }

        public long Version { get; private set; }

        protected AggregateRoot()
        {
            events = new List<IEvent>();
        }

        protected abstract void Apply<T>(T @event) where T : IEvent;

        public void Load(IEnumerable<IEvent> history)
        {
            foreach (var e in history)
            {
                Apply(e);
                Version++;
            }
        }

        protected void AddDomainEvent(IEvent @event) => events.Add(@event);

        public IReadOnlyCollection<IEvent> GetDomainEvents() => events.AsReadOnly();
    }
}
