using Core.Features.Customers.Dtos;

namespace Core.Featuress.Customer;

public static class UserMapping
{
    public static void Configure()
    {
        TypeAdapterConfig<User, GetUser>.NewConfig()
            .Map(dest => dest.Gender, src => src.Gender.ToString());
    }
}
