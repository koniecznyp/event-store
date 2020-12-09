using System;

namespace BankEventStore.Application.Exceptions
{
    public class AccountAlreadyExistsException : ApplicationException
    {
        public AccountAlreadyExistsException(Guid accountId)
            : base($"Account with id {accountId} already exists")
        {
        }
    }
}
