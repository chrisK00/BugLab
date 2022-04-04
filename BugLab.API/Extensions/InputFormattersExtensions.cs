using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Linq;

namespace BugLab.API.Extensions
{
    public static class InputFormattersExtensions
    {
        public static FormatterCollection<IInputFormatter> InsertJsonPatch(this FormatterCollection<IInputFormatter> formatters)
        {
            var builder = new ServiceCollection()
           .AddLogging()
           .AddMvc()
           .AddNewtonsoftJson()
           .Services.BuildServiceProvider();

            var formatter = builder
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();

            formatters.Insert(0, formatter);
            return formatters;
        }
    }
}
