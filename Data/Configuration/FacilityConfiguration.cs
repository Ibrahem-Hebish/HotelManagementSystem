namespace Data.Configuration;

public class FacilityConfiguration : IEntityTypeConfiguration<Facilitiy>
{
    public void Configure(EntityTypeBuilder<Facilitiy> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("nvarchar(30)");

        builder.ToTable(nameof(Facilitiy));
    }
}
