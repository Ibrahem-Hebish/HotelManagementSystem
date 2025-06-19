using Core.Features.Users.Dtos;

namespace Core.Features.Users;

public static class UserMapping
{
    public static void Configure()
    {
        TypeAdapterConfig<User, GetUser>.NewConfig()
            .Map(dest => dest.Gender, src => src.Gender.ToString());
    }
}
