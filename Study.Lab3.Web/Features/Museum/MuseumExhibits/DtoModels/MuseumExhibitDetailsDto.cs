namespace Study.Lab3.Web.Features.Museum.MuseumExhibits.DtoModels;

public sealed record MuseumExhibitDetailsDto
{
    /// <summary>
    /// Идентификатор деталей экспоната
    /// </summary>
    public Guid IsnMuseumExhibitDetails { get; init; }

    /// <summary>
    /// Идентификатор экспоната
    /// </summary>
    public Guid IsnMuseumExhibit { get; init; }

    /// <summary>
    /// Происхождение экспоната
    /// </summary>
    public string Origin { get; init; }

    /// <summary>
    /// Создатель/Автор
    /// </summary>
    public string Creator { get; init; }

    /// <summary>
    /// Год создания
    /// </summary>
    public int? CreationYear { get; init; }

    /// <summary>
    /// Материал изготовления
    /// </summary>
    public string Material { get; init; }

    /// <summary>
    /// Размеры
    /// </summary>
    public string Dimensions { get; init; }

    /// <summary>
    /// Вес в килограммах
    /// </summary>
    public double? Weight { get; init; }

    /// <summary>
    /// Историческая эпоха
    /// </summary>
    public string HistoricalPeriod { get; init; }

    /// <summary>
    /// Состояние сохранности
    /// </summary>
    public string Condition { get; init; }
}
