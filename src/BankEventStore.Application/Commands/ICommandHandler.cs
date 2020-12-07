using System.Threading.Tasks;

namespace BankEventStore.Application.Commands
{
    public interface ICommandHandler<T> where T : class, ICommand
    {
        Task HandleAsync(T command);
    }
}
