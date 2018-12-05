using SignalRAsAService.Core.Interfaces;
using SignalRAsAService.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace SignalRAsAService.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Snapshot> Snapshots { get; set; }
        public DbSet<StoredEvent> StoredEvents { get; set; }
    }
}
