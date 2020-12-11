using BankEventStore.Application.Exceptions;
using BankEventStore.Core;
using System.Threading.Tasks;

namespace BankEventStore.Application.Commands.WithdrawMoney
{
    internal class WithdrawMoneyHandler : ICommandHandler<WithdrawMoney>
    {
        private readonly IEventStore aggregateStore;

        public WithdrawMoneyHandler(IEventStore aggregateStore)
        {
            this.aggregateStore = aggregateStore;
        }

        public async Task HandleAsync(WithdrawMoney command)
        {
            var account = await aggregateStore.LoadAsync<Account>(command.AccountId);

            if (account == null)
                throw new AccountNotExistsException(command.AccountId);

            account.Withdraw(command.Amount);

            await aggregateStore.AppendChangesAsync(account);
        }
    }
}
