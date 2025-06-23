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
            User admin = new()
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

            Customer customer = new()
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

            Vendor vendor = new()
            {
                Id = "f3b1c2d3-e4f5-6789-abcd-ef0123456789",
                FirstName = "Ali",
                LastName = "Ahmed",
                UserName = "Ali_Ahmed",
                Email = "ibrahemahmed@gmail.com",
                PhoneNumber = "01224157272",
                Country = "Egypt",
                City = "Cairo",
                Gender = UserGender.Male,
                BirthDate = new DateOnly(1985, 1, 20),
            };

            var isAdminCreated = await userManager.CreateAsync(admin, "Hema123#");

            if (isAdminCreated.Succeeded)
                await userManager.AddToRoleAsync(admin, "Admin");

            var isCustomerCreated = await userManager.CreateAsync(customer, "Hema123#");

            if (isCustomerCreated.Succeeded)
                await userManager.AddToRoleAsync(customer, "Customer");

            var isVendorCreated = await userManager.CreateAsync(vendor, "Ali123##");

            if (isVendorCreated.Succeeded)
            {
                await userManager.AddToRoleAsync(vendor, "Vendor");
            }
        }
    }

    public static async Task SeedVendors(UserManager<Vendor> userManager)
    {

    }

    public static async Task SeedHotels(AppDbContext context)
    {
        if (!context.Hotels.Any())
        {
            List<Hotel> hotels = [
                new Hotel
                {
                    Name = "Hotel California",
                    Phone = "+1 800 123 4567",
                    Country = "USA",
                    City = "Los Angeles",
                    Street = "123 Sunset Blvd",
                    IsDeleted = false,
                    OwnerId = "f3b1c2d3-e4f5-6789-abcd-ef0123456789"
                },
                new Hotel
                {
                    Name = "The Grand Budapest Hotel",
                    Phone = "+48 123 456 789",
                    Country = "Europe",
                    City = "Zubrowka",
                    Street = "456 Grand St",
                    IsDeleted = false,
                    OwnerId = "f3b1c2d3-e4f5-6789-abcd-ef0123456789"
                }
            ];

            await context.Hotels.AddRangeAsync(hotels);
            await context.SaveChangesAsync();
        }
    }
    public static async Task SeedRooms(AppDbContext context)
    {
        List<Room> rooms =
            [
                new Room
                {
                    Description = "Deluxe Room with sea view",
                    Status = RoomStatus.Available,
                    DiscountPercentage = 0,
                    Type = RoomType.Deluxe,
                    Area = 30,
                    PricePerNight = 150.00m,
                    HotelId = 1,
                    IsDeleted = false
                },
                new Room
                {
                    Description = "Standard Room with city view",
                    Area = 25,
                    Status = RoomStatus.Available,
                    DiscountPercentage = 0,
                    Type = RoomType.Single,
                    PricePerNight = 100.00m,
                    HotelId = 2,
                    IsDeleted = false
                }

            ];
        if (!context.Rooms.Any())
        {
            await context.Rooms.AddRangeAsync(rooms);
            await context.SaveChangesAsync();
        }


    }
    public static async Task SeedRoomFacilities(AppDbContext context)
    {
        List<RoomFacilities> roomFacilities =
            [
                new RoomFacilities { FacilityId = 1, RoomId = 1 },
                new RoomFacilities { FacilityId = 2, RoomId = 1 },
                new RoomFacilities { FacilityId = 1, RoomId = 2 }
            ];

        if (!context.RoomFacilities.Any())
        {
            await context.RoomFacilities.AddRangeAsync(roomFacilities);
            await context.SaveChangesAsync();
        }

    }
}

