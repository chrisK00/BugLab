using BugLab.Shared.Headers;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BugLab.API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int pageNumber, int pageSize, int totalPages, int totalItems)
        {
            var paginationHeader = new PaginationHeader(pageNumber, pageSize, totalItems, totalPages);
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, jsonOptions));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}