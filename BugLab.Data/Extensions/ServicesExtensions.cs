using BugLab.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BugLab.Data.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddDataServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("Default")));
            services.AddSingleton<IDateProvider, DateProvider>();
        }
    }
}