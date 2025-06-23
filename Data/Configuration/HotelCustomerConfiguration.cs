namespace Data.Configuration;

public class HotelCustomerConfiguration : IEntityTypeConfiguration<HotelCustomer>
{
    public void Configure(EntityTypeBuilder<HotelCustomer> builder)
    {
        builder.HasKey(x => new { x.HotelId, x.CustomerId });

        builder.HasOne(x => x.Hotel)
            .WithMany(x => x.HotelCustomers)
            .HasForeignKey(x => x.HotelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.HotelCustomers)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable(nameof(HotelCustomer));
    }
}
