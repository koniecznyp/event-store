using BankEventStore.Core.Events;
using System;

namespace BankEventStore.Core
{
    public class Account : AggregateRoot, IEntity
    {
        private decimal balance;

        private DateTime createdAt;

        private Account()
        {
        }

        public static Account Create(Guid accountId)
        {
            var account = new Account();

            var @event = new AccountCreated(accountId, DateTime.UtcNow);

            account.Apply(@event);
            account.AddDomainEvent(@event);

            return account;
        }

        protected override void Apply<T>(T @event)
        {
            this.When((dynamic)@event);
        }

        private void When(AccountCreated @event)
        {
            Id = @event.AccountId;
            createdAt = @event.CreatedAt;
            balance = 0;
        }
    }
}
