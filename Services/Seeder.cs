namespace Services;

public static class Seeder
{
    public static async Task SeedRoles(RoleManager<Role> roleManager)
    {
        if (!roleManager.Roles.Any())
        {
            await roleManager.CreateAsync(new Role { Name = "Admin" });
            await roleManager.CreateAsync(new Role { Name = "User" });
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

            var result = await userManager.CreateAsync(user, "Hema123#");

            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
