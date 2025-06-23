namespace Data.Configuration;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {

        builder.Property(x => x.Rowversion)
               .IsRowVersion();

        builder.HasOne(x => x.Customer)
               .WithMany(x => x.Reservations);

        builder.HasOne(x => x.Room)
               .WithMany(x => x.Reservations)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Hotel)
               .WithMany(x => x.Reservations)
               .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable(nameof(Reservation));
    }
}
