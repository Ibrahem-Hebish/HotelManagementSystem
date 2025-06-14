namespace Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.City)
            .HasColumnType("nvarchar(50)");

        builder.Property(x => x.Country)
            .HasColumnType("nvarchar(30)");

        builder.HasMany(x => x.Hotels)
            .WithMany(x => x.Customers)
            .UsingEntity<HotelEvaluations>(builder => builder
                                       .HasOne(x => x.Hotel)
                                       .WithMany(x => x.HotelEvaluations)
                                       .HasForeignKey(x => x.HotelId),
                                        builder => builder
                                       .HasOne(x => x.User)
                                       .WithMany(x => x.HotelEvaluations)
                                       .OnDelete(DeleteBehavior.NoAction));



        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.ToTable(nameof(User));
    }
}

