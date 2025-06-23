
namespace Services.Repositories.Classes;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<List<HotelReviews>> GetUserReviewsToHotels(string userId, Tracking tracking, CancellationToken cancellationToken)
    {
        try
        {
            var user = await GetUserWithEvaluations(userId, cancellationToken);

            var hotelEvaluations = context.HotelReviews
            .Where(x => x.UserId == user.Id)
            .Include(x => x.Hotel)
            .AsQueryable();

            if (tracking == Tracking.AsTracking)
                hotelEvaluations = hotelEvaluations.AsTracking();

            return await hotelEvaluations.ToListAsync(cancellationToken);
        }
        catch
        {
            throw new KeyNotFoundException($"User with ID {userId} not found.");
        }

    }

    public async Task<List<Hotel>> GetUserHotels(string userId, Tracking tracking, CancellationToken cancellationToken)
    {
        try
        {
            var user = await GetUserWithHotels(userId, cancellationToken);

            var hotels = user.Hotels.AsQueryable();

            if (tracking == Tracking.AsTracking)
                hotels = hotels.AsTracking();

            return await hotels.ToListAsync(cancellationToken);
        }
        catch
        {
            throw new KeyNotFoundException($"User with ID {userId} not found.");
        }


    }

    public async Task<Reservation> GetUserLastReservation(string userId, Tracking tracking, CancellationToken cancellationToken)
    {
        try
        {
            var user = await GetUserWithReservations(userId, cancellationToken);

            if (tracking == Tracking.AsNoTracking)
            {
                return user.Reservations.AsQueryable()
                    .Include(x => x.Hotel)
                    .AsTracking()
                    .OrderByDescending(x => x.CheckInDate)
                    .FirstOrDefault()!;
            }

            return user.Reservations
                .AsQueryable()
                .Include(x => x.Hotel)
                .OrderByDescending(x => x.CheckInDate)
                .LastOrDefault()!;
        }
        catch
        {
            throw new KeyNotFoundException($"User with ID {userId} not found.");
        }


    }

    public async Task<List<Reservation>> GetUserReservations(string userId, Tracking tracking, CancellationToken cancellationToken)
    {
        try
        {
            var user = await GetUserWithReservations(userId, cancellationToken);

            var reservations = user.Reservations.AsQueryable();

            if (tracking == Tracking.AsTracking)
            {
                reservations = reservations.AsTracking().Include(x => x.Hotel);
            }
            else
            {
                reservations = reservations.Include(x => x.Hotel);
            }

            return await reservations.ToListAsync(cancellationToken);
        }
        catch
        {
            throw new KeyNotFoundException($"User with ID {userId} not found.");
        }
    }

    private async Task<Customer> GetUserWithReservations(string userId, CancellationToken cancellationToken)
    {
        var user = await context.Customers.FindAsync(userId, cancellationToken);

        if (user is not null)
        {
            await context.Entry(user)
                .Collection(x => x.Reservations)
                .LoadAsync(cancellationToken);
        }

        return user ?? throw new KeyNotFoundException($"User with ID {userId} not found.");

    }

    private async Task<Vendor> GetUserWithHotels(string userId, CancellationToken cancellationToken)
    {
        var user = await context.Vendors.FindAsync(userId, cancellationToken);

        if (user is not null)
        {
            await context.Entry(user)
                .Collection(x => x.Hotels)
                .LoadAsync(cancellationToken);
        }

        return user ?? throw new KeyNotFoundException($"User with ID {userId} not found.");
    }

    private async Task<User> GetUserWithEvaluations(string userId, CancellationToken cancellationToken)
    {
        var user = await context.Customers.FindAsync(userId, cancellationToken);

        if (user is not null)
        {
            await context.Entry(user)
                .Collection(x => x.HotelReviews)
                .LoadAsync(cancellationToken);
        }

        return user ?? throw new KeyNotFoundException($"User with ID {userId} not found.");
    }

}
