using Serilog;
using System.Diagnostics;

namespace HotelSystem.Middlewares;

public class ResponseTimeMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var stopWatch = Stopwatch.StartNew();

        await next(context);

        stopWatch.Stop();

        var responsTime = stopWatch.ElapsedMilliseconds;

        Log.Information($"Response with path {context.Request.Path} took {responsTime} ms.");
    }
}
