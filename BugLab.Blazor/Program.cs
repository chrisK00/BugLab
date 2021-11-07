using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BugLab.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/") });

            builder.Services.AddMudServices().AddMudBlazorSnackbar(cfg =>
            {
                cfg.ClearAfterNavigation = false;
                cfg.ShowCloseIcon = true;
                cfg.PreventDuplicates = false;
            });

            await builder.Build().RunAsync();
        }
    }
}
