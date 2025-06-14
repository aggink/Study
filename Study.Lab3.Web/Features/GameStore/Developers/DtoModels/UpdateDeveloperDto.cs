using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.GameStore.Developers.DtoModels;

/// <summary>
/// DTO для обновления разработчика
/// </summary>
public sealed record UpdateDeveloperDto
{
    /// <summary>
    /// Идентификатор разработчика
    /// </summary>
    [Required]
    public Guid IsnDeveloper { get; init; }

    /// <summary>
    /// Название компании разработчика
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Developer.CompanyName)]
    public string CompanyName { get; init; }

    /// <summary>
    /// Страна
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Developer.Country)]
    public string Country { get; init; }

    /// <summary>
    /// Дата основания компании
    /// </summary>
    public DateTime? FoundedDate { get; init; }

    /// <summary>
    /// Веб-сайт
    /// </summary>
    [MaxLength(ModelConstants.Developer.Website)]
    public string Website { get; init; }

    /// <summary>
    /// Email для связи
    /// </summary>
    [MaxLength(ModelConstants.Developer.ContactEmail)]
    [EmailAddress]
    public string ContactEmail { get; init; }

    /// <summary>
    /// Активен ли разработчик
    /// </summary>
    public bool IsActive { get; init; }

    /// <summary>
    /// Описание компании
    /// </summary>
    [MaxLength(ModelConstants.Developer.Description)]
    public string Description { get; init; }
}