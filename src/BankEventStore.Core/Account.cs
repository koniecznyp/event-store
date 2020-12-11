using BankEventStore.Core.Events;
using BankEventStore.Core.Exceptions;
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

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new IncorrectDepositAmountException();

            var @event = new MoneyDeposited(
                accountId: Id,
                amount: amount);

            Apply(@event);
            AddDomainEvent(@event);
        }

        public void Withdraw(decimal amount)
        {
            if (amount > balance)
                throw new InsufficientFundsException();

            var @event = new MoneyWithdrawn(
                accountId: Id,
                amount: amount);

            Apply(@event);
            AddDomainEvent(@event);
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

        private void When(MoneyDeposited @event)
        {
            balance += @event.Amount;
        }

        private void When(MoneyWithdrawn @event)
        {
            balance -= @event.Amount;
        }
    }
}
