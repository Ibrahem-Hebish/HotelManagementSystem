using Data.DBContext;
using Hangfire;

namespace HotelSystem;

public static class AppExtention
{
    public static async Task ConfigureAsync(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await Seeder.SeedRoles(roleManager);
            await Seeder.SeedUsers(userManager);
            await Seeder.SeedHotels(dbContext);
            await Seeder.SeedRooms(dbContext);
            await Seeder.SeedRoomFacilities(dbContext);

        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExeptionHandlerMiddleware>();

        app.UseMiddleware<ResponseTimeMiddleware>();

        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseRouting();

        app.UseRateLimiter();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseHangfireDashboard();

        app.MapHangfireDashboard("/hangfire")
        .RequireAuthorization(r => r.RequireRole("Admin"));

        RecurringJob.AddOrUpdate<BackGroundJobs>(
           "RealeseAvillableRooms",
        job => job.ReleaseAvillableRooms(CancellationToken.None)
           , Cron.Daily);

        app.MapControllers();
    }
}
