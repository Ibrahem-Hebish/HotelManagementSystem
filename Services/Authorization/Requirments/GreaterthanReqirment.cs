namespace Services.Authorization.Requirments;

public class GreaterthanReqirment(int age) : IAuthorizationRequirement
{
    public int Age { get; set; } = age;
}
