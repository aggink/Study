using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Shelter.Customers.DtoModels;

public sealed record UpdateShelterCustomerDto
{
    [Required]
    public Guid IsnCustomer { get; init; }

    [Required]
    [MaxLength(ModelConstants.ShelterCustomer.Name)]
    public string Name { get; init; }

    [Required]
    [MaxLength(ModelConstants.ShelterCustomer.Name)]
    public string LastName { get; init; }

    [Required]
    [MaxLength(ModelConstants.ShelterCustomer.Description)]
    public string Description { get; init; }

    [Required]
    [MaxLength(ModelConstants.ShelterCustomer.Address)]
    public string Address { get; init; }

    [Required]
    [MaxLength(ModelConstants.ShelterCustomer.PhoneNumber)]
    public string PhoneNumber { get; init; }

    [Required]
    [MaxLength(ModelConstants.ShelterCustomer.Email)]
    public string Email { get; init; }
}