using System;

namespace BankEventStore.Application.Exceptions
{
    public class AccountNotExistsException : ApplicationException
    {
        public AccountNotExistsException(Guid accountId)
            : base($"Account with id {accountId} does not exists")
        {
        }
    }
}
