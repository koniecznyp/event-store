using System;

namespace BankEventStore.Core.Events
{
    public class MoneyDeposited : IEvent
    {
        public MoneyDeposited(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }

        public Guid AccountId { get; }
        public decimal Amount { get; }
    }
}
