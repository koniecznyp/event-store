using System;

namespace BankEventStore.Core
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
