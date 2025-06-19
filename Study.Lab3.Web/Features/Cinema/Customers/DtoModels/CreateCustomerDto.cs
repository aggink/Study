using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Customers.DtoModels;

public sealed record CreateCustomerDto
{
    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Customer.FirstName)]
    public string FirstName { get; init; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Customer.LastName)]
    public string LastName { get; init; }

    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Customer.Email)]
    [EmailAddress]
    public string Email { get; init; }

    /// <summary>
    /// Телефон
    /// </summary>
    [MaxLength(ModelConstants.Customer.Phone)]
    [Phone]
    public string Phone { get; init; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; init; }
}