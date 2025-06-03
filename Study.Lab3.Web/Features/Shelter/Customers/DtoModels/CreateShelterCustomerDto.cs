using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Shelter.Customers.DtoModels;

public sealed record CreateShelterCustomerDto
{
    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.ShelterCustomer.Name)]
    public string Name { get; init; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.ShelterCustomer.Name)]
    public string LastName { get; init; }
    
    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.ShelterCustomer.Email)]
    public string Email { get; init; }
    
    /// <summary>
    /// Телефон
    /// </summary>
    [MaxLength(ModelConstants.ShelterCustomer.PhoneNumber)]
    [Phone]
    public string PhoneNumber { get; init; }
    
    [Required]
    [MaxLength(ModelConstants.ShelterCustomer.Address)]
    public string Address { get; set; }
}