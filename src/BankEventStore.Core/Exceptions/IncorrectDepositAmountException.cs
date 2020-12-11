namespace BankEventStore.Core.Exceptions
{
    public class IncorrectDepositAmountException : DomainException
    {
        public IncorrectDepositAmountException()
            : base("Incorrect deposit amount.")
        {
        }
    }
}
