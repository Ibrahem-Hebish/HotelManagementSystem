namespace Data.Configuration;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.Property(x => x.Name)
            .HasColumnType("nvarchar(50)");

        builder.Property(x => x.Country)
            .HasColumnType("nvarchar(30)");

        builder.Property(x => x.City)
            .HasColumnType("nvarchar(50)");

        builder.Property(x => x.Street)
            .HasColumnType("nvarchar(100)");

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
                        new Hotel
                        {
                            Id = 1,
                            Name = "Hotel California",
                            Phone = "+1 800 123 4567",
                            Country = "USA",
                            City = "Los Angeles",
                            Street = "123 Sunset Blvd",
                            IsDeleted = false
                        },
                        new Hotel
                        {
                            Id = 2,
                            Name = "The Grand Budapest Hotel",
                            Phone = "+48 123 456 789",
                            Country = "Europe",
                            City = "Zubrowka",
                            Street = "456 Grand St",
                            IsDeleted = false
                        }
                                );

        builder.ToTable(nameof(Hotel));
    }
}
