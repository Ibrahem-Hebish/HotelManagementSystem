using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data.DBContext;

public class AppDbContext : IdentityDbContext<User, Role, string>
{
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<HotelReviews> HotelReviews { get; set; }
    public DbSet<HotelCustomer> HotelCustomers { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Facilitiy> Facilities { get; set; }
    public DbSet<RoomFacilities> RoomFacilities { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<UserToken> UserTokens { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public AppDbContext()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var config = new ConfigurationBuilder()
            .AddJsonFile("json.json")
            .Build();

        var connectionString = config.GetSection("connectionstring").Value;

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionString)
                .AddInterceptors(new SoftDeleteInterceptor());
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Room).Assembly);
    }

}
