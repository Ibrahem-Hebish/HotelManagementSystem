namespace Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(typeof(GetFacilityById).Assembly);

            opt.AddOpenBehavior(typeof(QueryCachingPipeline<,>));
            opt.AddOpenBehavior(typeof(CommandCachingPipeline<,>));

            opt.NotificationPublisher = new TaskWhenAllPublisher();
        });

        services.AddMapster();

        RoomMapping.Configure();

        services.AddHttpContextAccessor();

        services.AddValidatorsFromAssemblyContaining<GetFacilityById>();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
