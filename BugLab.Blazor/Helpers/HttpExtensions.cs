using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BugLab.Blazor.Helpers;
public static class HttpExtensions
{
    public static async Task<HttpResponseMessage> NewtonsoftPatchAsync<T>(this HttpClient client, string requestUri, JsonPatchDocument<T> patchDocument)
    where T : class
    {
        var writer = new StringWriter();

        new JsonSerializer().Serialize(writer, patchDocument);
        var json = writer.ToString();

        var content = new StringContent(json, Encoding.UTF8, "application/json-patch+json");
        return await client.PatchAsync(requestUri, content);
    }
}
