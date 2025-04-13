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

        builder.ToTable(nameof(Hotel));
    }
}
