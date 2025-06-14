using Services.SpecificationPattern;
using Services.SpecificationPattern.HotelSpecifications;

namespace Services.Repositories.Classes;

public class HotelRepository(AppDbContext context)
    : IHotelRepository
{
    private readonly DbSet<Hotel> dbSet = context.Hotels;
    public async Task<List<Hotel>> GetAsync(Tracking tracking, CancellationToken cancellationToken)
    {
        var hotels = dbSet.AsQueryable();

        if (tracking == Tracking.AsTracking)
        {
            hotels = hotels.AsTracking();
        }

        return await hotels.ToListAsync(cancellationToken);
    }

    public async Task<List<Hotel>> GetByCityAsync(string city, Tracking tracking, CancellationToken cancellationToken)
    {
        var hotels = dbSet
            .Where(x => x.City == city)
            .Include(x => x.Rooms)
            .ThenInclude(x => x.Photos)
            .AsSplitQuery();

        if (tracking == Tracking.AsTracking)
            hotels = hotels.AsTracking();

        return await hotels.ToListAsync(cancellationToken);

    }

    public async Task<List<Hotel>> GetByCountryAsync(string country, Tracking tracking, CancellationToken cancellationToken)
    {
        var hotels = dbSet
            .Where(x => x.Country == country)
            .Include(x => x.Rooms)
            .ThenInclude(x => x.Photos)
            .AsSplitQuery();

        if (tracking == Tracking.AsTracking)
            hotels = hotels.AsTracking();

        return await hotels.ToListAsync(cancellationToken);

    }

    public async Task<Hotel> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        Hotel? hotel = await dbSet.FindAsync(id, cancellationToken);

        if (hotel is not null)
        {
            await dbSet.Entry(hotel)
                 .Collection(x => x.Rooms)
                 .Query()
                 .Include(x => x.Photos)
                 .AsSplitQuery()
                 .LoadAsync(cancellationToken);
        }

        return hotel!;
    }

    public async Task<(List<Hotel>, int count)> Paginate(int pageSize, int lastId, Tracking tracking, CancellationToken cancellationToken)
    {

        if (pageSize < 1) pageSize = 10;

        if (lastId < 0) lastId = 0;

        var hotels = dbSet.AsQueryable();

        var count = dbSet.Count();

        if (tracking == Tracking.AsTracking)
            hotels = hotels.AsTracking();

        var result = await hotels
            .Where(x => x.Id > lastId)
            .OrderBy(x => x.Id)
            .Take(pageSize)
            .Include(x => x.Rooms)
            .ThenInclude(x => x.Photos)
            .AsSplitQuery()
            .ToListAsync(cancellationToken);

        return (result, count);
    }

    public async Task<List<Hotel>> Search(ISpecification<Hotel> specification, HotelIncludeOptions includeOptions)
    {
        if (specification is null)
            return null!;

        var query = dbSet
                          .AsNoTracking()
                          .Where(specification.Filter)
                          .AsQueryable();

        if (includeOptions.IncludeCustomers)
            query = query.Include(x => x.Customers);

        if (includeOptions.IncludeReservations)
            query = query.Include(x => x.Reservations);

        if (includeOptions.IncludeEvaluations)
            query = query.Include(x => x.HotelEvaluations);

        if (includeOptions.IncludeRooms)
            query = query.Include(x => x.Rooms);


        return await query.ToListAsync();


    }

}



