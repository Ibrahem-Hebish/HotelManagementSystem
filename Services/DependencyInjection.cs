using Services.Repositories.Classes;

namespace servicess;

public static class DependencyInjection
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        var signingKey = configuration["jwtsigningkey"];

        services.AddSerilog();

        Log.Logger = new LoggerConfiguration()
                         .ReadFrom.Configuration(configuration)
                         .CreateLogger();


        services.AddMemoryCache();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.Decorate<IUnitOfWork, Logger>();


        services.Configure<EmailSettings>(configuration.GetSection("Email"));

        services.AddTransient<IEmailService, EmailService>();


        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IRepository<Room>), typeof(Repository<Room>));
        services.AddScoped(typeof(IRepository<Hotel>), typeof(Repository<Hotel>));
        services.AddScoped(typeof(IRepository<Facilitiy>), typeof(Repository<Facilitiy>));
        services.AddScoped(typeof(IRepository<Reservation>), typeof(Repository<Reservation>));
        services.AddScoped(typeof(IRepository<UserToken>), typeof(Repository<UserToken>));


        services.Decorate(typeof(IRepository<>), typeof(CachingDecorator<>));
        services.Decorate(typeof(IRepository<>), typeof(LoggingDecorator<>));

        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IFacilityRepository, FacilityRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IUserTokenRepository, UserTokenRepository>();

        services.Configure<JwtOptions>(configuration.GetSection("jwt"));

        var jwt = configuration.GetSection("jwt").Get<JwtOptions>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();

        services.AddAuthentication()
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
                {
                    opt.SaveToken = true;

                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwt!.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwt!.Audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                               Encoding.UTF8.GetBytes(configuration["jwtsigningkey"]!)),
                    };
                });


        services.AddScoped<IAuthorizationHandler, GreaterThanHandler>();

        services.AddScoped<IAuthorizationHandler, AccessUserEvaluationHandler>();

        services.AddAuthorization(opt =>
        {
            opt.AddPolicy("Egypt", builder =>
            {
                builder.RequireAssertion(context =>
                {
                    var country = context.User.FindFirst("Country");

                    if (country is null)
                        return false;

                    return country.Value == "Egypt";
                });
            });

            opt.AddPolicy("GreaterThan18", builder =>
            {
                builder.AddRequirements(new GreaterthanReqirment(18));
            });

            opt.AddPolicy("AccessUserEvaluation", builder =>
            {
                builder.AddRequirements(new AccessEvaluationPermission());
            });
        });

        return services;
    }
}
