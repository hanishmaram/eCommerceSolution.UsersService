
namespace eCommerce.API.Middlewares;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex, ex.GetType().ToString());

            if (ex.InnerException is not null)
            {
                _logger.LogError(ex.InnerException, ex.InnerException.GetType().ToString());
            }

            httpContext.Response.StatusCode = 500;

            await httpContext.Response.WriteAsJsonAsync(new { Error= "Internal Service Error." });
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
