using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace PfMsSalesPlatform.Middalware
{
    public class GlobalMiddalwareExceptions:IMiddleware
    {
        private readonly ILogger<GlobalMiddalwareExceptions> _logger;
        public GlobalMiddalwareExceptions(ILogger<GlobalMiddalwareExceptions> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Console.WriteLine(ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails details = new() 
                { 
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Internal server error",
                    Title = "Internal server error",
                    Detail = "An internal error has ocurred"
                };

                string datail = JsonSerializer.Serialize(details);
                await context.Response.WriteAsync(datail);
                context.Response.ContentType = "application/json";
            }
        }
    }
}
