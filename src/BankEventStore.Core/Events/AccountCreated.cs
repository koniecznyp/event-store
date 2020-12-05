using System;

namespace BankEventStore.Core.Events
{
    public class AccountCreated : IEvent
    {
        public AccountCreated(Guid accountId, DateTime createdAt)
        {
            AccountId = accountId;
            CreatedAt = createdAt;
        }

        public Guid AccountId { get; }

        public DateTime CreatedAt { get; }
    }
}
