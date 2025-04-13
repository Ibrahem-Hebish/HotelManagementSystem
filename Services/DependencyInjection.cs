namespace Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection service)
    {
        var configuration = new ConfigurationBuilder()
                                   .AddJsonFile("ServiceSettings.json")
                                    .Build();
        service.AddSerilog();

        Log.Logger = new LoggerConfiguration()
                         .ReadFrom.Configuration(configuration)
                         .CreateLogger();


        service.AddMemoryCache();

        service.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        service.AddTransient(typeof(IRepository<Room>), typeof(Repository<Room>));
        service.AddTransient(typeof(IRepository<Hotel>), typeof(Repository<Hotel>));
        service.AddTransient(typeof(IRepository<Customer>), typeof(Repository<Customer>));
        service.AddTransient(typeof(IRepository<Facilitiy>), typeof(Repository<Facilitiy>));
        service.AddTransient(typeof(IRepository<Reservation>), typeof(Repository<Reservation>));

        service.Decorate(typeof(IRepository<>), typeof(CachingDecorator<>));
        service.Decorate(typeof(IRepository<>), typeof(LoggingDecorator<>));

        return service;
    }
}
