namespace Data.Configuration;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {

        builder.Property(x => x.RowVersion)
            .IsRowVersion();

        builder.Property(x => x.Description)
            .HasColumnType("nvarchar(800)");

        builder.Property(x => x.TotalPrice)
            .HasComputedColumnSql("PricePerNight * (1 - DiscountPercentage / 100.0)");

        builder.HasOne(x => x.Hotel)
            .WithMany(x => x.Rooms)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Photos)
            .WithOne(x => x.Room)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Facilitiy)
            .WithMany(x => x.Rooms)
            .UsingEntity<RoomFacilities>();

        builder.HasQueryFilter(x => !x.IsDeleted);


        builder.ToTable(nameof(Room), t =>
        {
            t.HasCheckConstraint("chk_Area_Must_Be_Greater_than_6", "Area > 6");
        });
    }


}
