using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.CarDealership.Customers.DtoModels;

public sealed record CreateCarDealershipCustomerDto
{
    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.CarDealershipCustomer.FirstName)]
    public string FirstName { get; init; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.CarDealershipCustomer.LastName)]
    public string LastName { get; init; }

    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.CarDealershipCustomer.Email)]
    [EmailAddress]
    public string Email { get; init; }

    /// <summary>
    /// Телефон
    /// </summary>
    [MaxLength(ModelConstants.CarDealershipCustomer.Phone)]
    [Phone]
    public string Phone { get; init; }

    /// <summary>
    /// Адрес
    /// </summary>
    [MaxLength(ModelConstants.CarDealershipCustomer.Address)]
    public string Address { get; init; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.CarDealershipCustomer.PassportNumber)]
    public string PassportNumber { get; init; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; init; }
}