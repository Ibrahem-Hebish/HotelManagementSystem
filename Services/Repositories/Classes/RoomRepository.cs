namespace Services.Repositories.Classes;

public class RoomRepository(AppDbContext context)
    : Repository<Room>(context), IRoomRepository
{
}
