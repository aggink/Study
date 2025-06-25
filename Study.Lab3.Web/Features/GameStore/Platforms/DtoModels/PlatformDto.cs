namespace Study.Lab3.Web.Features.GameStore.Platforms.DtoModels;

/// <summary>
/// DTO для отображения платформы
/// </summary>
public sealed record PlatformDto
{
    /// <summary>
    /// Идентификатор платформы
    /// </summary>
    public Guid IsnPlatform { get; init; }

    /// <summary>
    /// Название платформы
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Производитель
    /// </summary>
    public string Manufacturer { get; init; }

    /// <summary>
    /// Тип платформы (Console, PC, Mobile, etc.)
    /// </summary>
    public string Type { get; init; }

    /// <summary>
    /// Дата выхода платформы
    /// </summary>
    public DateTime? ReleaseDate { get; init; }

    /// <summary>
    /// Активна ли платформа
    /// </summary>
    public bool IsActive { get; init; }

    /// <summary>
    /// Описание платформы
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Поколение платформы
    /// </summary>
    public int? Generation { get; init; }

    /// <summary>
    /// Поддерживает ли онлайн игры
    /// </summary>
    public bool SupportsOnlineGaming { get; init; }
}