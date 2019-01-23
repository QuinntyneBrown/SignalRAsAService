using SignalRAsAService.Core.Identity;
using SignalRAsAService.Core.Interfaces;
using SignalRAsAService.Core.Models;
using SignalRAsAService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace SignalRAsAService.API
{
    public class AppInitializer : IDesignTimeDbContextFactory<AppDbContext>
    {
        public static void Seed(
            IDateTime dateTime,
            IServiceScopeFactory services)
        {

        }

        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddUserSecrets(typeof(Startup).GetTypeInfo().Assembly)
                .Build();

            return new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(configuration["Data:DefaultConnection:ConnectionString"])
                .Options);
        }
    }
    
}
