using Services.SpecificationPattern;
using Services.SpecificationPattern.RoomSpecifications;

namespace Services.Repositories.Interfaces;

public interface IRoomRepository
{
    Task<Room> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<Room>> GetAsync(Tracking tracking, CancellationToken cancellationToken);
    Task<List<Room>> Search(ISpecification<Room> specification, RoomIncludeOptions options, CancellationToken cancellationToken);


}