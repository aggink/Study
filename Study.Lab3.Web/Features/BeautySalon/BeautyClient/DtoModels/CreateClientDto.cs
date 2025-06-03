using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyClient.DtoModels;

public sealed record CreateClientDto
{
    /// <summary>
    /// ID записи
    /// </summary>
    [Required]
    public Guid IsnAppointment { get; init; }

    /// <summary>
    /// Имя клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.BeautyClient.FirstName)]
    public string FirstName { get; init; }

    /// <summary>
    /// Фамилия клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.BeautyClient.LastName)]
    public string LastName { get; init; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.BeautyClient.PhoneNumber)]
    public string PhoneNumber { get; init; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.BeautyClient.EmailAddress)]
    public string EmailAddress { get; init; }
}
