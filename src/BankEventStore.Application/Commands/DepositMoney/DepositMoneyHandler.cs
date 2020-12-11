using BankEventStore.Application.Exceptions;
using BankEventStore.Core;
using System.Threading.Tasks;

namespace BankEventStore.Application.Commands.DepositMoney
{
    internal class DepositMoneyHandler : ICommandHandler<DepositMoney>
    {
        private readonly IEventStore aggregateStore;

        public DepositMoneyHandler(IEventStore aggregateStore)
        {
            this.aggregateStore = aggregateStore;
        }

        public async Task HandleAsync(DepositMoney command)
        {
            var account = await aggregateStore.LoadAsync<Account>(command.AccountId);

            if (account == null)
                throw new AccountNotExistsException(command.AccountId);

            account.Deposit(command.Amount);

            await aggregateStore.AppendChangesAsync(account);
        }
    }
}
