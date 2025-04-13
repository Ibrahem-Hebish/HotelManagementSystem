namespace Services.Repositories.Classes;

public class ReservationRepository(AppDbContext context)
    : Repository<Reservation>(context), IReservationRepository
{
}
