using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Photography.Clients.DtoModels;

public sealed record UpdatePhotographyClientDto
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    public Guid IsnPhotographyClient { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyClient.FirstName)]
    public string FirstName { get; init; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyClient.LastName)]
    public string LastName { get; init; }

    /// <summary>
    /// Телефон
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyClient.Phone)]
    public string Phone { get; init; }

    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyClient.Email)]
    [EmailAddress]
    public string Email { get; init; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; init; }

    /// <summary>
    /// Комментарии о клиенте
    /// </summary>
    [MaxLength(ModelConstants.PhotographyClient.Notes)]
    public string Notes { get; init; }
}
