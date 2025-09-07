namespace Study.Lab3.Web.Features.Dormitory.Rooms.DtoModels;

public sealed record DormitoryRoomDto
{
    /// <summary>
    /// Идентификатор комнаты
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Номер комнаты
    /// </summary>
    public string RoomNumber { get; init; } = string.Empty;

    /// <summary>
    /// Этаж
    /// </summary>
    public int Floor { get; init; }

    /// <summary>
    /// Площадь комнаты в квадратных метрах
    /// </summary>
    public double Area { get; init; }

    /// <summary>
    /// Максимальное количество жильцов
    /// </summary>
    public int MaxOccupants { get; init; }

    /// <summary>
    /// Текущее количество жильцов
    /// </summary>
    public int CurrentOccupants { get; init; }

    /// <summary>
    /// Стоимость проживания в месяц
    /// </summary>
    public decimal MonthlyRent { get; init; }

    /// <summary>
    /// Есть ли балкон
    /// </summary>
    public bool HasBalcony { get; init; }

    /// <summary>
    /// Есть ли собственный санузел
    /// </summary>
    public bool HasPrivateBathroom { get; init; }

    /// <summary>
    /// Описание комнаты
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; init; }
}
