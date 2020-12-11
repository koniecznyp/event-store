using System;

namespace BankEventStore.Application.Commands.WithdrawMoney
{
    public class WithdrawMoney : ICommand
    {
        public WithdrawMoney(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }

        public Guid AccountId { get; }
        public decimal Amount { get; }
    }
}
