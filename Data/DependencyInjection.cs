namespace Data;

using Microsoft.AspNetCore.Identity;

public static class DependencyInjection
{
    public static IServiceCollection AddData(this IServiceCollection Service, IConfiguration configuration)
    {

        Service.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetSection("connectionstring").Value)
                .AddInterceptors(new SoftDeleteInterceptor());
        });

        Service.AddIdentityCore<User>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequiredLength = 8;
            o.User.RequireUniqueEmail = true;
        })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        return Service;
    }
}