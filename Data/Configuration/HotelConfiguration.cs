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

        builder.HasOne(x => x.Owner)
            .WithMany(x => x.Hotels)
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Customers)
            .WithMany(x => x.Hotels)
            .UsingEntity<HotelReviews>(builder =>

                builder.HasOne(x => x.Customer)
                    .WithMany(x => x.HotelReviews)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.NoAction)
            , builder =>

                builder.HasOne(x => x.Hotel)
                    .WithMany(x => x.HotelReviews)
                    .HasForeignKey(x => x.HotelId)
                    .OnDelete(DeleteBehavior.Cascade)
            );

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.ToTable(nameof(Hotel));
    }
}
