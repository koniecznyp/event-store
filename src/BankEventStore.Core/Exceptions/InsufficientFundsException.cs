namespace BankEventStore.Core.Exceptions
{
    public class InsufficientFundsException : DomainException
    {
        public InsufficientFundsException()
            : base("insufficient funds to withdraw money.")
        {
        }
    }
}
