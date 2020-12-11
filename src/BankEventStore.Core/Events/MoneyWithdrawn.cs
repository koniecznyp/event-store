using System;

namespace BankEventStore.Core.Events
{
    public class MoneyWithdrawn : IEvent
    {
        public MoneyWithdrawn(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }

        public Guid AccountId { get; }
        public decimal Amount { get; }
    }
}
