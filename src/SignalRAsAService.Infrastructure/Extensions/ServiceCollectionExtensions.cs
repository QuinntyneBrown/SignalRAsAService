using SignalRAsAService.Core.Interfaces;
using SignalRAsAService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SignalRAsAService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {                
        public static IServiceCollection AddDataStore(this IServiceCollection services,
                                               string connectionString, bool useInMemoryDatabase = false)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();

            return services.AddDbContext<AppDbContext>(options =>
            {
                _ = useInMemoryDatabase 
                ? options.UseInMemoryDatabase(databaseName: "SignalRAsAService")
                : options.UseSqlServer(connectionString, b => b.MigrationsAssembly("SignalRAsAService.Infrastructure"));
            });          
        }
    }
}
