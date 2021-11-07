using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace BugLab.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddTransient<IRestClient>(p => new RestClient(new Uri($"{builder.HostEnvironment.BaseAddress}api")));

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
