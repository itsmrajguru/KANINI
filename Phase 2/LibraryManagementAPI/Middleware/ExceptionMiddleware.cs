using System.Net;
using System.Text.Json;

namespace LibraryManagementAPI.Middleware
{
    // Catches any unhandled exception and returns a clean JSON error response
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the full error for debugging
                _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        // Write a consistent JSON error response
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            // Map specific exceptions to proper HTTP status codes
            context.Response.StatusCode = ex switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound,          // 404
                InvalidOperationException => (int)HttpStatusCode.BadRequest,   // 400
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized, // 401
                _ => (int)HttpStatusCode.InternalServerError                   // 500
            };

            var response = new
            {
                statusCode = context.Response.StatusCode,
                message = ex switch
                {
                    KeyNotFoundException => ex.Message,
                    InvalidOperationException => ex.Message,
                    UnauthorizedAccessException => ex.Message,
                    _ => "Something went wrong. Please try again."
                },
                detail = ex.Message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
