using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace BugLab.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = ex switch
                {
                    KeyNotFoundException => StatusCodes.Status404NotFound,
                    InvalidOperationException => StatusCodes.Status400BadRequest,
                    UnauthorizedAccessException => StatusCodes.Status403Forbidden,
                    _ => StatusCodes.Status500InternalServerError
                };

                var result = _env.IsDevelopment() 
                    ? JsonSerializer.Serialize(new { message = ex.Message, stackTrace = ex?.StackTrace })
                    : JsonSerializer.Serialize(new { message = ex.Message });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
