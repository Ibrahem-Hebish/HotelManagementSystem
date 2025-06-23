using Core.Features.Customers.Dtos;

namespace Core.Features.Vendor.Queries;

public sealed record GetCustomers(string VendorId) : IRequest<Response<List<GetUser>>>, IValidatorRequest
{
}
