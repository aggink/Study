namespace Study.Lab3.Web.Features.Shelter.Customers.DtoModels;

public sealed record ShelterCustomerDto
{
    public Guid IsnCustomer { get; init; }
    
    public string Name { get; init; }
    
    public string LastName { get; init; }
    
    public string Description { get; init; }

    public string Address { get; init; }

    public string PhoneNumber { get; init; }
    
    public string Email { get; init; }
}