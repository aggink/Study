using Study.Lab3.Web.Features.GameStore.Games.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Developers.DtoModels;

/// <summary>
/// DTO для отображения разработчика с количеством игр
/// </summary>
public sealed record DeveloperWithDetailsDto
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

    /// <summary>
    /// Количество игр
    /// </summary>
    public int GamesCount { get; init; }

    /// <summary>
    /// Список игр, разработанных этим разработчиком
    /// </summary>
    public GameDto[] Games { get; init; }
}