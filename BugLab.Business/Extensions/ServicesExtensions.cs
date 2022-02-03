using BugLab.Business.BackgroundServices;
using BugLab.Business.Helpers;
using BugLab.Business.Interfaces;
using BugLab.Business.PipelineBehaviors;
using BugLab.Business.Services;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BugLab.Business.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServicesExtensions).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            services.AddMemoryCache();

            TypeAdapterConfig.GlobalSettings.Scan(typeof(Mappings).Assembly);

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
           
            services.AddHostedService<RemoveDeletedBugsService>();
        }
    }
}
