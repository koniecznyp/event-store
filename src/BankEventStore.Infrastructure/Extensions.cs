using BankEventStore.Application.Commands;
using BankEventStore.Core;
using BankEventStore.Infrastructure.Dispatchers;
using BankEventStore.Infrastructure.Postgres;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankEventStore.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCommandHandlers();
            services.AddCommandDispatcher();

            services.AddPostgresDb(configuration);

            services.AddScoped<IEventStore, PostgresEventStore>();
        }

        private static void AddCommandHandlers(this IServiceCollection services)
        {
            services.Scan(s => s
                .FromAssemblies(typeof(ICommand).Assembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
        }

        private static void AddCommandDispatcher(this IServiceCollection services)
        {
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        }
    }
}
