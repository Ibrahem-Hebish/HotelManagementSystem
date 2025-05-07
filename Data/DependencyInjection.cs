namespace Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDataDependancies(this IServiceCollection Service, IConfiguration configuration)
    {

        Service.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetSection("connectionstring").Value);
        });

        Service.AddIdentityCore<User>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequiredLength = 8;
            o.User.RequireUniqueEmail = true;
        })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<AppDbContext>();

        return Service;
    }
}