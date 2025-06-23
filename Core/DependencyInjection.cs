using Core.Featuress.Customer;
using Hangfire;
using Microsoft.Extensions.Configuration;

namespace Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetRequiredSection("ConnectionString").Value;

        // Configure Hangfire Client

        services.AddHangfire(c =>
         c.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
          .UseSimpleAssemblyNameTypeSerializer()
          .UseRecommendedSerializerSettings()
          .UseSqlServerStorage(connectionString)
          );

        services.AddHangfireServer();

        services.AddScoped<BackGroundJobs>();

        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(typeof(GetFacilityById).Assembly);

            opt.AddOpenBehavior(typeof(QueryCachingPipeline<,>));
            opt.AddOpenBehavior(typeof(CommandCachingPipeline<,>));

            opt.NotificationPublisher = new TaskWhenAllPublisher();
        });

        services.AddMapster();

        RoomMapping.Configure();
        HotelMapping.Configure();
        UserMapping.Configure();

        services.AddHttpContextAccessor();

        services.AddValidatorsFromAssemblyContaining<GetFacilityById>();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
