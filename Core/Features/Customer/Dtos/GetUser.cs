﻿namespace Core.Features.Customers.Dtos;

public class GetUser
{
    public string Id { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string UserName { get; set; } = "";
    public string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
}
