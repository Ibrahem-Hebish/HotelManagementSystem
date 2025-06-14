using Services.SpecificationPattern;
using Services.SpecificationPattern.HotelSpecifications;

namespace Services.Repositories.Interfaces;

public interface IHotelRepository

{
    Task<Hotel> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<Hotel>> GetAsync(Tracking tracking, CancellationToken cancellationToken);
    Task<List<Hotel>> GetByCityAsync(string city, Tracking tracking, CancellationToken cancellationToken);
    Task<List<Hotel>> GetByCountryAsync(string country, Tracking tracking, CancellationToken cancellationToken);
    Task<List<Hotel>> Search(ISpecification<Hotel> specification, HotelIncludeOptions includeOptions);
    Task<(List<Hotel>, int count)> Paginate(int pageSize, int lastId, Tracking tracking, CancellationToken cancellationToken);
}
