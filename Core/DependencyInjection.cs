using Core.Mediator.MediatorPipelines.Commands;
using Core.Mediator.MediatorPipelines.Query;
using MediatR.NotificationPublishers;

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

        services.AddHttpContextAccessor();

        services.AddValidatorsFromAssemblyContaining<GetFacilityById>();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
