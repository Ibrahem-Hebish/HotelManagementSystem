namespace HotelSystem.Middlewares;

public class ExeptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            var problemDetails = new ProblemDetails()
            {
                Status = context.Response.StatusCode,
                Detail = ex.Message
            };

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
    }
}
