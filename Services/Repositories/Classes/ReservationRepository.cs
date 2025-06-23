using Services.SpecificationPattern;
using Services.SpecificationPattern.ReservationSpecifications;

namespace Services.Repositories.Classes;

public class ReservationRepository(AppDbContext context)
    : IReservationRepository
{
    private readonly DbSet<Reservation> dbSet = context.Reservations;

    public async Task<List<Reservation>> GetAsync(Tracking tracking, CancellationToken cancellationToken)
    {
        var reservations = dbSet.AsQueryable();

        if (tracking == Tracking.AsTracking)
        {
            reservations = reservations.AsTracking();
        }

        return await reservations.ToListAsync(cancellationToken);
    }

    public async Task<Reservation> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var reservation = await dbSet.FindAsync(id, cancellationToken);

        if (reservation is not null)
        {
            await dbSet.Entry(reservation)
                .Reference(x => x.Hotel)
                .LoadAsync(cancellationToken);

            await dbSet.Entry(reservation)
                .Reference(x => x.Customer)
                .LoadAsync(cancellationToken);

            await dbSet.Entry(reservation)
                .Reference(x => x.Room)
                .LoadAsync(cancellationToken);
        }

        return reservation!;
    }

    public async Task<bool> HasConflictAsync(int roomId, DateTime checkInDate, DateTime checkOutDate, CancellationToken cancellationToken = default)
    {

        var hasConfilict = await dbSet.AnyAsync(r => r.RoomId == roomId &&
             r.CheckInDate < checkOutDate &&
             r.CheckOutDate > checkInDate,
        cancellationToken);

        return hasConfilict;
    }

    public async Task<List<Reservation>> Search(ISpecification<Reservation> spec, ReservationIncludeOptions options, CancellationToken cancellationToken)
    {
        var query = dbSet.AsQueryable()
                          .Where(spec.Filter);

        if (options.IncludeHotel)
            query = query.Include(x => x.Hotel);

        if (options.IncludeCustomer)
            query = query.Include(x => x.Customer);

        if (options.IncludeRoom)
            query = query.Include(x => x.Room);

        return await query.ToListAsync(cancellationToken);
    }

    public decimal CalculateReservationPrice(Room room, DateTime checkIn, DateTime checkOut, FoodServiceType service)
    {
        var days = (checkOut - checkIn).Days;
        var total = room.TotalPrice * days;

        return service switch
        {
            FoodServiceType.Breakfast => total + 20 * days,
            FoodServiceType.HalfBoard => total + 50 * days,
            FoodServiceType.FullBoard => total + 100 * days,
            _ => total
        };
    }
}
