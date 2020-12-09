using BankEventStore.Core;
using BankEventStore.Core.Events;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BankEventStore.Infrastructure.Postgres
{
    public class PostgresEventStore : IEventStore
    {
        private readonly BankContext context;

        private readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Objects
        };

        public PostgresEventStore(BankContext context)
        {
            this.context = context;
        }

        public async Task AppendChangesAsync<T>(T aggregate) where T : AggregateRoot
        {
            context.EventStore.AddRange(
                aggregate.GetDomainEvents().Select(e =>
                    new EventStore(
                        id: Guid.NewGuid(),
                        aggregateType: aggregate.GetType().FullName,
                        aggregateId: aggregate.Id,
                        version: aggregate.Version,
                        timestamp: DateTime.UtcNow.Ticks,
                        name: e.GetType().FullName,
                        data: JsonConvert.SerializeObject(e, SerializerSettings))));
            await context.SaveChangesAsync();
        }

        public async Task<T> LoadAsync<T>(Guid aggregateId) where T : AggregateRoot
        {
            var storedEvents = await context.EventStore
                .Where(x => x.AggregateId == aggregateId)
                .OrderBy(x => x.Timestamp)
                .Select(x => x.Data)
                .ToListAsync();

            if (!storedEvents.Any())
                return null;

            var aggregate = (T)Activator.CreateInstance(typeof(T), true);

            aggregate.Load(
                storedEvents.Select(eventData =>
                    JsonConvert.DeserializeObject(eventData, SerializerSettings) as IEvent));

            return aggregate;
        }
    }
}
