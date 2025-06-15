using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.CarService.Owners.DtoModels;

public sealed record UpdateOwnerDto
{
    /// <summary>
    /// Идентификатор владельца
    /// </summary>
    [Required]
    public Guid IsnOwner { get; init; }
 
    /// <summary>
    /// Имя владельца
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Owner.FirstName)]
    public string FirstName { get; init; }
 
    /// <summary>
    /// Фамилия владельца
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Owner.SecondName)]
    public string SecondName { get; init; }
 
    /// <summary>
    /// Номер телефона
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Owner.PhoneNumber)]
    public string PhoneNumber { get; init; }
 
    /// <summary>
    /// Email
    /// </summary>
    [MaxLength(ModelConstants.Owner.Email)]
    public string Email { get; init; }
 
    /// <summary>
    /// Адрес
    /// </summary>
    [MaxLength(ModelConstants.Owner.Address)]
    public string Address { get; init; }
}