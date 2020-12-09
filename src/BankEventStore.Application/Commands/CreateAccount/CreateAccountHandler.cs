using BankEventStore.Application.Exceptions;
using BankEventStore.Core;
using System.Threading.Tasks;

namespace BankEventStore.Application.Commands.CreateAccount
{
    internal class CreateAccountHandler : ICommandHandler<CreateAccount>
    {
        private readonly IEventStore aggregateStore;

        public CreateAccountHandler(IEventStore aggregateStore)
        {
            this.aggregateStore = aggregateStore;
        }

        public async Task HandleAsync(CreateAccount command)
        {
            var account = await aggregateStore.LoadAsync<Account>(command.AccountId);
            if (account != null)
                throw new AccountAlreadyExistsException(command.AccountId);

            var newAccount = Account.Create(command.AccountId);

            await aggregateStore.AppendChangesAsync(newAccount);
        }
    }
}
