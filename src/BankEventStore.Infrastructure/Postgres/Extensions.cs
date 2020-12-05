using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankEventStore.Infrastructure.Postgres
{
    public static class Extensions
    {
        public static void AddPostgresDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<BankContext>(o =>
                    o.UseNpgsql(configuration.GetConnectionString("BankApp")));
        }
    }
}
