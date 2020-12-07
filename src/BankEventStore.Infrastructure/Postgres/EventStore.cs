using System;

namespace BankEventStore.Infrastructure.Postgres
{
    public class EventStore
    {
        public EventStore(Guid id, string aggregateType, Guid aggregateId, long version, long timestamp, string name, string data)
        {
            Id = id;
            AggregateType = aggregateType;
            AggregateId = aggregateId;
            Version = version;
            Timestamp = timestamp;
            Name = name;
            Data = data;
        }

        public Guid Id { get; set; }
        public string AggregateType { get; set; }
        public Guid AggregateId { get; set; }
        public long Version { get; set; }
        public long Timestamp { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
    }
}
