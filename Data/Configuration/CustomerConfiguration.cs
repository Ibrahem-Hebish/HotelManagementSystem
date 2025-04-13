namespace Data.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {

        builder.Property(x => x.Name)
            .HasColumnType("nvarchar(50)");

        builder.Property(x => x.Country)
            .HasColumnType("nvarchar(30)");

        builder.ToTable(nameof(Customer));
    }
}
