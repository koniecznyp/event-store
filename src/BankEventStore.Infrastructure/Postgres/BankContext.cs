using Microsoft.EntityFrameworkCore;

namespace BankEventStore.Infrastructure.Postgres
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<EventStore> EventStore { get; set; }
    }
}
