namespace Study.Lab3.Web.Features.GameStore.Games.DtoModels;

/// <summary>
/// DTO для отображения игры с деталями разработчика
/// </summary>
public sealed record GameWithDetailsDto
{
    /// <summary>
    /// Идентификатор игры
    /// </summary>
    public Guid IsnGame { get; init; }

    /// <summary>
    /// Идентификатор разработчика
    /// </summary>
    public Guid? IsnDeveloper { get; init; }

    /// <summary>
    /// Название компании разработчика
    /// </summary>
    public string DeveloperName { get; init; }

    /// <summary>
    /// Название игры
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    /// Описание игры
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; init; }

    /// <summary>
    /// Дата выхода
    /// </summary>
    public DateTime ReleaseDate { get; init; }

    /// <summary>
    /// Жанр
    /// </summary>
    public string Genre { get; init; }

    /// <summary>
    /// Возрастной рейтинг
    /// </summary>
    public string AgeRating { get; init; }

    /// <summary>
    /// Активна ли игра в продаже
    /// </summary>
    public bool IsActive { get; init; }
}