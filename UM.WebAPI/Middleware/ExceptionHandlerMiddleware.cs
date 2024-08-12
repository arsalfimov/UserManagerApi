using System.Text.Json;
using UM.Domain.Exceptions;

namespace UM.WebAPI.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await ErrorHandler(ex, httpContext);
        }
    }

    private static async Task ErrorHandler(Exception exception, HttpContext context)
    {
        switch (exception)
        {
            case EmailAlreadyExistsException:
            case RoleAlreadyExistsException:
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                break;

            case ArgumentException:
            case JsonException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;

            case NotFoundException:
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                break;


            default:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        var result = JsonSerializer.Serialize(new { error = exception.Message });

        context.Response.ContentType = "text/json";
        await context.Response.WriteAsync(result);
    }
}

public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
