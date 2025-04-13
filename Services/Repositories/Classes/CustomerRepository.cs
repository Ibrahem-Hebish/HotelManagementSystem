namespace Services.Repositories.Classes;

public class CustomerRepository(AppDbContext context)
    : Repository<Customer>(context), ICustomerRepository
{
}
