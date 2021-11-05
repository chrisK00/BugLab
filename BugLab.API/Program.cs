using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace BugLab.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
           .WriteTo.Console(theme: AnsiConsoleTheme.Code)
           .CreateLogger();
        }
    }
}