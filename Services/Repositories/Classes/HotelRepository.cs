namespace Services.Repositories.Classes;

public class HotelRepository(AppDbContext context)
    : Repository<Hotel>(context), IHotelRepository
{
}

