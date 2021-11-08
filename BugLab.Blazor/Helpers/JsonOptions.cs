using System.Text.Json;
using System.Text.Json.Serialization;

namespace BugLab.Blazor.Helpers
{
    public static class JsonOptions
    {
        public static JsonSerializerOptions Defaults()
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            options.Converters.Add(new JsonStringEnumConverter());
            return options;
        }
    }
}
