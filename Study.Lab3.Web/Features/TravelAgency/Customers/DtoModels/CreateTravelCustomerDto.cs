using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.TravelAgency.Customers.DtoModels;

public sealed record CreateTravelCustomerDto
{
    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.TravelCustomer.SurName)]
    public string SurName { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.TravelCustomer.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Отчество
    /// </summary>
    [MaxLength(ModelConstants.TravelCustomer.PatronymicName)]
    public string PatronymicName { get; init; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    [Required]
    public DateTime DateOfBirth { get; init; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.TravelCustomer.PassportNumber)]
    public string PassportNumber { get; init; }

    /// <summary>
    /// Телефон
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.TravelCustomer.Phone)]
    public string Phone { get; init; }

    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.TravelCustomer.Email)]
    public string Email { get; init; }

    /// <summary>
    /// Адрес проживания
    /// </summary>
    [MaxLength(ModelConstants.TravelCustomer.Address)]
    public string Address { get; init; }

    /// <summary>
    /// VIP клиент
    /// </summary>
    public bool IsVip { get; init; }
}
