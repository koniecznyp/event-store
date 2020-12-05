using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BankEventStore.Infrastructure.Postgres;

namespace BankEventStore.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPostgresDb(configuration);
        }
    }
}
