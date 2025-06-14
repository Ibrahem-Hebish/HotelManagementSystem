
namespace Services.Repositories.Classes;

public class FacilityRepository(AppDbContext context)
    : IFacilityRepository
{
    private readonly DbSet<Facilitiy> dbSet = context.Facilities;
    public async Task<List<Facilitiy>> GetAsync(Tracking tracking, CancellationToken cancellationToken)
    {
        var facilities = dbSet.AsQueryable();

        if (tracking == Tracking.AsTracking)
            facilities = facilities.AsTracking();

        return await facilities
            .ToListAsync(cancellationToken);
    }

    public Task<Facilitiy?> GetByIdAsync(int id, Tracking tracking, CancellationToken cancellationToken)
    {
        var facility = dbSet.AsQueryable();

        if (tracking == Tracking.AsTracking)
            facility = facility.AsTracking();

        return facility
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
