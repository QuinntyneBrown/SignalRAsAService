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
            IEventStore eventStore,
            IServiceScopeFactory services,
            IRepository repository)
        {
            UserConfiguration.Seed(dateTime, eventStore, repository);
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


    internal class UserConfiguration
    {
        public static void Seed(IDateTime dateTime, IEventStore eventStore, IRepository repository)
        {
            var salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var hashedPassword = new PasswordHasher().HashPassword(salt, "P@ssw0rd");

            var user = new User("quinntynebrown@gmail.com", salt, hashedPassword);

            eventStore.Save(user);

            //82DCA1D3-A41C-4681-A95C-FD2AD8537AA2	7B5271AD-FF81-4F03-9CAB-F4735310BA54	UserCreated	User	SignalRAsAService.Core.Models.User, SignalRAsAService.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null	2	{"UserId":"7b5271ad-ff81-4f03-9cab-f4735310ba54","Username":"quinntynebrown@gmail.com","Salt":"AAAAAAAAAAAAAAAAAAAAAA==","Password":"hllT6kdbLnTJwi96oBSPqv8NQz21sOBzJ6E48o0zQrU=","CorrelationId":"00000000-0000-0000-0000-000000000000","CausationId":"00000000-0000-0000-0000-000000000000","ActivityId":"00000000-0000-0000-0000-000000000000"}	SignalRAsAService.Core.DomainEvents.UserCreated, SignalRAsAService.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null	2018-12-05 09:54:27.0609078	0
        }
    }


    internal class RoleConfiguration
    {

    }
}
