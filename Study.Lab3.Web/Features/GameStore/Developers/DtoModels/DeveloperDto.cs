namespace Study.Lab3.Web.Features.GameStore.Developers.DtoModels;

/// <summary>
/// DTO для отображения разработчика
/// </summary>
public sealed record DeveloperDto
{
    /// <summary>
    /// Идентификатор разработчика
    /// </summary>
    public Guid IsnDeveloper { get; init; }

    /// <summary>
    /// Название компании разработчика
    /// </summary>
    public string CompanyName { get; init; }

    /// <summary>
    /// Страна
    /// </summary>
    public string Country { get; init; }

    /// <summary>
    /// Дата основания компании
    /// </summary>
    public DateTime? FoundedDate { get; init; }

    /// <summary>
    /// Веб-сайт
    /// </summary>
    public string Website { get; init; }

    /// <summary>
    /// Email для связи
    /// </summary>
    public string ContactEmail { get; init; }

    /// <summary>
    /// Активен ли разработчик
    /// </summary>
    public bool IsActive { get; init; }

    /// <summary>
    /// Описание компании
    /// </summary>
    public string Description { get; init; }
}