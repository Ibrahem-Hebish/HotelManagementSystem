namespace HotelSystem;

public static class DependencyInjection
{
    public static IServiceCollection AddWeb(this IServiceCollection Services)
    {
        Services.AddControllers();

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
