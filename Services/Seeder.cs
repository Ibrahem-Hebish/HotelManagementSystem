using Data.Enums;

namespace Services;

public static class Seeder
{
    public static async Task SeedRoles(RoleManager<Role> roleManager)
    {
        if (!roleManager.Roles.Any())
        {
            await roleManager.CreateAsync(new Role { Name = "Admin" });
            await roleManager.CreateAsync(new Role { Name = "Customer" });
            await roleManager.CreateAsync(new Role { Name = "Vendor" });
        }
    }

    public static async Task SeedUsers(UserManager<User> userManager)
    {
        if (!userManager.Users.Any())
        {
            User user = new()
            {
                FirstName = "Ibrahem",
                LastName = "Ahmed",
                UserName = "Ibrahem_Hebish",
                Email = "ibrahemhebish@gmail.com",
                PhoneNumber = "01224157271",
                Country = "Egypt",
                City = "Elmahalla",
                Gender = Data.Enums.UserGender.Male,
                BirthDate = new DateOnly(2001, 1, 22),
            };

            User user2 = new()
            {
                FirstName = "Ibrahem",
                LastName = "Hebish",
                UserName = "Ibrahem_Ahmed",
                Email = "ibrahemhebish777@gmail.com",
                PhoneNumber = "01224157270",
                Country = "Egypt",
                City = "Elmahalla",
                Gender = UserGender.Male,
                BirthDate = new DateOnly(2001, 1, 22),
            };

            var result = await userManager.CreateAsync(user, "Hema123#");

            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, "Admin");

            var result2 = await userManager.CreateAsync(user2, "Hema123#");

            if (result2.Succeeded)
                await userManager.AddToRoleAsync(user2, "Customer");
        }
    }
}
