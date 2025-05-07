namespace HotelSystem;

public static class AppExtention
{
    public static async Task ConfigureAsync(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

            await Seeder.SeedRoles(roleManager);
            await Seeder.SeedUsers(userManager);

        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExeptionHandlerMiddleware>();

        app.UseHttpsRedirection();

        app.UseMiddleware<ResponseTimeMiddleware>();

        app.UseRouting();

        app.UseCors("AllowAll");

        app.UseRateLimiter();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();
    }
}
