using System.Threading.Tasks;

namespace BankEventStore.Application.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : class, ICommand;
    }
}
