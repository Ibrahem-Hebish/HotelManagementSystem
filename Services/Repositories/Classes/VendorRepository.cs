
namespace Services.Repositories.Classes;

public class VendorRepository(AppDbContext context)
    : IVendorRepository
{

    public async Task<List<Customer>> GetCustomersAsync(string vendorId, CancellationToken cancellationToken)
    {
        var customers = await context.Hotels
                                   .Where(h => h.OwnerId == vendorId)
                                    .SelectMany(h => h.Customers)
                                    .ToListAsync();

        return customers;


    }
}
