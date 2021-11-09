using BugLab.Business.Helpers;
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
            TypeAdapterConfig.GlobalSettings.Scan(typeof(Mappings).Assembly);
        }
    }
}
