namespace Services.Repositories.Interfaces;

public interface IVendorRepository
{
    Task<List<Customer>> GetCustomersAsync(string vendorId, CancellationToken cancellationToken);
}
