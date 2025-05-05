using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace NutriSportPro.API.Ressources;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;

    /// <summary>
    /// Handles unhandled exceptions and returns a server error response.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    /// <param name="exception">The exception that occurred.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A boolean indicating whether the exception was handled successfully.</returns>
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception.Message);

        var details = new ProblemDetails
        {
            Detail = $"{exception.Message}{(exception.InnerException is not null ? $",{exception.InnerException!.Message}" : string.Empty)}",
            Instance = "API",
            Status = (int)HttpStatusCode.InternalServerError,
            Title = "API Error",
            Type = "Server Error"
        };

        var response = JsonSerializer.Serialize(details);
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(response, cancellationToken);

        return true;
    }
}