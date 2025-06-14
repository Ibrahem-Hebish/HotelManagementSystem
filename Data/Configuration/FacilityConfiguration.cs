namespace Data.Configuration;

public class FacilityConfiguration : IEntityTypeConfiguration<Facilitiy>
{
    public void Configure(EntityTypeBuilder<Facilitiy> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("nvarchar(30)");

        builder.HasData([
            new Facilitiy
            {
                Id = 1,
                Name = "Free Wi-Fi",
            },
            new Facilitiy
            {
                Id = 2,
                Name = "Swimming Pool",
            },
            new Facilitiy
            {
                Id = 3,
                Name = "Gym",
            },

        ]);

        builder.ToTable(nameof(Facilitiy));
    }
}

