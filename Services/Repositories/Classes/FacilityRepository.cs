namespace Services.Repositories.Classes;

public class FacilityRepository(AppDbContext context)
    : Repository<Facilitiy>(context), IFacilityRepository
{
}
