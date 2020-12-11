using System;

namespace BankEventStore.Application.Commands.DepositMoney
{
    public class DepositMoney : ICommand
    {
        public DepositMoney(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }

        public Guid AccountId { get; }
        public decimal Amount { get; }
    }
}
