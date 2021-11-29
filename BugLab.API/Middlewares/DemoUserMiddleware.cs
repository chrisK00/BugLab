using BugLab.Data.Extensions;
using BugLab.Shared.Responses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace BugLab.API.Middlewares
{
    public class DemoUserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public DemoUserMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestType = context.Request.Method;
            var userId = context.User.UserId();

            if (requestType == "GET" || _env.IsDevelopment() || string.IsNullOrWhiteSpace(userId) || userId != "757b2158-40c3-4917-9523-5861973a4d2e")
            {
                await _next(context);
                return;
            }

            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            var response = new ApiError($"You are not allowed to make a {requestType} request using the demo user");
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
