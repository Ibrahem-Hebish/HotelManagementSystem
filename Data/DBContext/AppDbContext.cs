using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data.DBContext;

public class AppDbContext : IdentityDbContext<User, Role, string>
{
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Facilitiy> Facilities { get; set; }
    public DbSet<RoomFacilities> RoomFacilities { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public AppDbContext() : base()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Room).Assembly);
    }

}
