namespace Services.Repositories.Interfaces;

public interface IFacilityRepository

{
    Task<Facilitiy?> GetByIdAsync(int id, Tracking tracking,
               CancellationToken cancellationToken);
    Task<List<Facilitiy>> GetAsync(Tracking tracking, CancellationToken cancellationToken);
}
