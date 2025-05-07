namespace Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.City)
            .HasColumnType("nvarchar(50)");

        builder.Property(x => x.Country)
            .HasColumnType("nvarchar(30)");

        builder.ToTable(nameof(User));
    }
}

