namespace Data.Configuration;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.Property(x => x.Path)
            .IsRequired()
            .HasColumnType("nvarchar(200)");

        builder.ToTable(nameof(Photo));
    }
}
