using BankEventStore.Application.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BankEventStore.Infrastructure.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceScopeFactory serviceFactory;

        public CommandDispatcher(IServiceScopeFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
        }

        public async Task DispatchAsync<T>(T command) where T : class, ICommand
        {
            using (var scope = serviceFactory.CreateScope())
            {
                var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<T>>();
                await handler.HandleAsync(command);
            }
        }
    }
}
