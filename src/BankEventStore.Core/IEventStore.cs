using System;
using System.Threading.Tasks;

namespace BankEventStore.Core
{
    public interface IEventStore
    {
        Task<T> LoadAsync<T>(Guid aggregateId) where T : AggregateRoot;

        Task AppendChangesAsync<T>(T aggregate) where T : AggregateRoot;
    }
}
