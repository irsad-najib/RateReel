[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    // Implement auth endpoints
}

// Controllers/UserController.cs
[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    // Implement user endpoints
}

// Controllers/AdminController.cs
[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    // Implement admin endpoints
}

// Middleware/ErrorHandlerMiddleware.cs
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
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
            _logger.LogError(ex, "An unhandled exception occurred");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new
            {
                error = "Internal Server Error"
            });
        }
    }
}