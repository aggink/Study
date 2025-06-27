using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Pharmacy.Customers.DtoModels;

public sealed record UpdatePharmacyCustomerDto
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    public Guid IsnCustomer { get; init; }
    
    /// <summary>
    /// Имя клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PharmacyCustomer.FirstNameMaxLength)]
    public string FirstName { get; init; }
    
    /// <summary>
    /// Фамилия клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PharmacyCustomer.LastNameMaxLength)]
    public string LastName { get; init; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    [MaxLength(ModelConstants.PharmacyCustomer.PhoneMaxLength)]
    public string Phone { get; init; }
    
    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    [MaxLength(ModelConstants.PharmacyCustomer.EmailMaxLength)]
    public string Email { get; init; }
    
    /// <summary>
    /// Адрес
    /// </summary>
    [MaxLength(ModelConstants.PharmacyCustomer.AddressMaxLength)]
    public string Address { get; init; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? DateOfBirth { get; init; }
    
    /// <summary>
    /// Есть ли медицинская страховка
    /// </summary>
    [Required]
    public bool HasInsurance { get; init; }
}