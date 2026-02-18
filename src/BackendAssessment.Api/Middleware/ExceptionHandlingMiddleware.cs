using System.Net;
using System.Text.Json;

namespace BackendAssessment.Api.Middleware;

/// <summary>
/// Global exception handling middleware that catches unhandled exceptions
/// and returns a structured JSON error response with a correlation ID.
/// </summary>
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            var correlationId = Guid.NewGuid().ToString();
            _logger.LogError(ex, "Unhandled exception occurred. CorrelationId: {CorrelationId}", correlationId);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                ArgumentException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var errorResponse = new
            {
                correlationId,
                message = ex switch
                {
                    KeyNotFoundException => ex.Message,
                    ArgumentException => ex.Message,
                    _ => "An unexpected error occurred."
                },
                statusCode = context.Response.StatusCode
            };

            var json = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(json);
        }
    }
}
