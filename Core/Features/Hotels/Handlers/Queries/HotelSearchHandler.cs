using Core.Features.Hotels.Dto;
using Core.Features.Hotels.Queries;
using Services.SpecificationPattern;
using Services.SpecificationPattern.HotelSpecifications;

namespace Core.Features.Hotels.Handlers.Queries;

public class HotelSearchHandler(
       IHotelRepository repository,
          IMapper mapper)
    : ResponseHandler,
    IRequestHandler<HotelSearch, Response<List<GetHotel>>>
{
    public async Task<Response<List<GetHotel>>> Handle(HotelSearch request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.HotelName) &&
                       string.IsNullOrWhiteSpace(request.City) &&
                                  string.IsNullOrWhiteSpace(request.Country) &&
                                             string.IsNullOrWhiteSpace(request.Street))
        {
            return BadRequest<List<GetHotel>>("At least one search parameter must be provided.");
        }

        List<ISpecification<Hotel>> specs = [];

        if (!String.IsNullOrWhiteSpace(request.HotelName))
            specs.Add(new HotelNameSpecification(request.HotelName));

        if (!String.IsNullOrEmpty(request.City))
            specs.Add(new HotelCitySpecification(request.City));

        if (!String.IsNullOrEmpty(request.Country))
            specs.Add(new HotelCountrySpecification(request.Country));

        if (!String.IsNullOrEmpty(request.Street))
            specs.Add(new HotelStreetSpecification(request.Street));

        var firstSpec = specs.FirstOrDefault();

        for (int i = 1; i < specs.Count; i++)
        {
            firstSpec = new OrSpecification<Hotel>(firstSpec!, specs[i]);
        }

        var includeSpec = new HotelIncludeOptions();

        includeSpec = includeSpec.WithRooms().WithEvaluations();

        var hotels = await repository.Search(firstSpec!, includeSpec);

        var hotelDtos = mapper.Map<List<GetHotel>>(hotels);

        return Success(hotelDtos);
    }
}
