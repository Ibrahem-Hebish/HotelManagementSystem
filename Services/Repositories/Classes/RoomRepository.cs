namespace Services.Repositories.Classes;

public class RoomRepository(AppDbContext context)
    : Repository<Room>(context), IRoomRepository
{

    public override async Task<Room> GetByIdAsync(int id, Tracking tracking,
               CancellationToken cancellationToken)
    {
        var room = await dbSet
            .Include(x => x.Hotel)
            .Include(x => x.Photos)
            .Include(x => x.Facilitiy)
            .AsSplitQuery()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return room!;
    }

    public override async Task<List<Room>> GetAsync(Tracking tracking)
    {
        var rooms = await dbSet
            .Include(x => x.Hotel)
            .Include(x => x.Photos)
            .Include(x => x.Facilitiy)
            .AsSplitQuery()
            .ToListAsync();

        return rooms;
    }
}
