namespace Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDataDependancies(this IServiceCollection Service)
    {

        Service.AddDbContext<AppDbContext>();

        Service.AddIdentityCore<User>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequiredLength = 8;
            o.User.RequireUniqueEmail = true;
            o.SignIn.RequireConfirmedEmail = true;
        })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<AppDbContext>();

        return Service;
    }
}