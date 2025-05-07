namespace HotelSystem;

public static class DependencyInjection
{
    public static IServiceCollection AddWeb(this IServiceCollection Services)
    {
        Services.AddControllers();

        Services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
            opt.ApiVersionReader = ApiVersionReader.Combine(
              new QueryStringApiVersionReader("version"),
              new HeaderApiVersionReader("version"),
              new UrlSegmentApiVersionReader());
        })
            .AddApiExplorer(opt =>
        {
            opt.GroupNameFormat = "'v'V";
            opt.SubstituteApiVersionInUrl = true;
        });

        Services.AddRateLimiter(opt =>
        {
            opt.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            opt.AddPolicy("UserLimit", context =>
            {
                return RateLimitPartition.GetSlidingWindowLimiter(
                    context.User.FindFirst("Id"), _ =>
                {
                    return new SlidingWindowRateLimiterOptions()
                    {
                        Window = TimeSpan.FromSeconds(10),
                        SegmentsPerWindow = 3,
                        PermitLimit = 4
                    };
                });
            });

            opt.AddPolicy("SignInLimit", context =>
            {
                return RateLimitPartition.GetSlidingWindowLimiter(
                    context.Connection.RemoteIpAddress, _ =>
                    {
                        return new SlidingWindowRateLimiterOptions()
                        {
                            Window = TimeSpan.FromSeconds(60),
                            SegmentsPerWindow = 3,
                            PermitLimit = 3
                        };
                    });
            });
        });

        Services.AddScoped<ExeptionHandlerMiddleware>();

        Services.AddAuthorization();

        Services.AddCors(opt =>
        {
            opt.AddPolicy("AllowAll", p =>
            {
                p.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });
        });

        Services.AddEndpointsApiExplorer();

        Services.AddSwaggerGen();

        return Services;
    }
}
