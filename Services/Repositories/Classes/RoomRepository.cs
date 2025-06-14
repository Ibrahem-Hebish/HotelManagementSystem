
using Services.SpecificationPattern;
using Services.SpecificationPattern.RoomSpecifications;

namespace Services.Repositories.Classes;

public class RoomRepository(AppDbContext context)
    : IRoomRepository
{
    private readonly DbSet<Room> dbSet = context.Rooms;

    public async Task<Room> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var room = await dbSet.FindAsync(id, cancellationToken);

        if (room is not null)
            await dbSet.Entry(room)
                .Collection(x => x.Photos)
                .LoadAsync();

        return room!;
    }
    public async Task<List<Room>> GetAsync(Tracking tracking, CancellationToken cancellationToken)
    {
        var rooms = dbSet
           .Include(x => x.Hotel)
           .Include(x => x.Photos)
           .Include(x => x.Facilitiy)
           .AsQueryable();

        if (tracking == Tracking.AsTracking)
            rooms = rooms.AsTracking();

        return await rooms.ToListAsync(cancellationToken);
    }
    public async Task<List<Room>> Search(ISpecification<Room> specification, RoomIncludeOptions options, CancellationToken cancellationToken)
    {
        var query = dbSet.Where(specification.Filter);

        if (options.IncludePhotos)
            query = query.Include(x => x.Photos);

        if (options.IncludeHotel)
            query = query.Include(x => x.Hotel);

        if (options.IncludeFacilities)
            query = query.Include(x => x.Facilitiy);

        if (options.IncludeReservations)
            query = query.Include(x => x.Reservations);

        return await query.ToListAsync(cancellationToken);

    }
}
