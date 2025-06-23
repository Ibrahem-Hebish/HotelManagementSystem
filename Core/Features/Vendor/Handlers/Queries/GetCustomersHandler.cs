using Core.Features.Customers.Dtos;
using Core.Features.Vendor.Queries;

namespace Core.Features.Vendor.Handlers.Queries;

public class GetCustomersHandler(
    IVendorRepository vendorRepository,
    IMapper mapper)

    : ResponseHandler
    , IRequestHandler<GetCustomers, Response<List<GetUser>>>
{
    public async Task<Response<List<GetUser>>> Handle(GetCustomers request, CancellationToken cancellationToken)
    {
        var customers = await vendorRepository.GetCustomersAsync(request.VendorId, cancellationToken);

        if (customers is null || customers.Count == 0)
            return NotFouned<List<GetUser>>("No customers found for the specified vendor.");

        var customerDtos = mapper.Map<List<GetUser>>(customers);

        return Success(customerDtos);
    }
}
