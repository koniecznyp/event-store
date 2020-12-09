using Newtonsoft.Json;
using System;

namespace BankEventStore.Application.Commands.CreateAccount
{
    public class CreateAccount : ICommand
    {
        [JsonConstructor]
        public CreateAccount(Guid accountId)
        {
            AccountId = accountId == Guid.Empty ? Guid.NewGuid() : accountId;
        }

        public Guid AccountId { get; }
    }
}
