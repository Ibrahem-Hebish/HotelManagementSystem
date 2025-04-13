
namespace Data.Entities;

public class User : IdentityUser<int>
{
    public bool Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}


