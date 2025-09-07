namespace Study.Lab3.Web.Features.Dormitory.Buildings.DtoModels;

public sealed record DormitoryBuildingDto
{
    /// <summary>
    /// Идентификатор здания
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Название здания
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Адрес здания
    /// </summary>
    public string Address { get; init; } = string.Empty;

    /// <summary>
    /// Количество этажей
    /// </summary>
    public int FloorsCount { get; init; }

    /// <summary>
    /// Общее количество комнат
    /// </summary>
    public int TotalRooms { get; init; }

    /// <summary>
    /// Год постройки
    /// </summary>
    public int BuildYear { get; init; }

    /// <summary>
    /// Имя управляющего
    /// </summary>
    public string? ManagerName { get; init; }

    /// <summary>
    /// Телефон управляющего
    /// </summary>
    public string? ManagerPhone { get; init; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; init; }
}
