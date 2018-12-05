using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignalRAsAService.Core;
using SignalRAsAService.Core.Behaviours;
using SignalRAsAService.Core.Common;
using SignalRAsAService.Core.Extensions;
using SignalRAsAService.Core.Interfaces;
using SignalRAsAService.Infrastructure;
using SignalRAsAService.Infrastructure.Data;
using SignalRAsAService.Infrastructure.Extensions;

namespace SignalRAsAService.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;
        
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDateTime, MachineDateTime>();
            services.AddTransient<IEventStore, EventStore>();
            services.AddHttpContextAccessor();
            services.AddSingleton<IRepository, Repository>();
            services.AddSingleton<ICommandPreProcessor, CommandPreProcessor>();
            services.AddSingleton<ICommandRegistry, CommandRegistry>();
            services.AddHostedService<QueuedHostedService>();
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();

            services.AddCustomMvc()
                .AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblyContaining<Startup>(); });

            services
                .AddCustomSecurity(Configuration)
                .AddCustomSignalR(Configuration["SignalR:DefaultConnection:ConnectionString"])
                .AddCustomSwagger()
                .AddDataStore(Configuration["Data:DefaultConnection:ConnectionString"],Configuration.GetValue<bool>("isTest"))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddMediatR(typeof(Startup).Assembly);
        }

        public void Configure(IApplicationBuilder app)
        {                    
            app.UseAuthentication()            
                .UseCors(CorsDefaults.Policy)            
                .UseMvc()
                .UseSignalR(routes => routes.MapHub<AppHub>("/hub"))
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "SignalRAsAService API");
                    options.RoutePrefix = string.Empty;
                });                                   
        }        
    }


}
