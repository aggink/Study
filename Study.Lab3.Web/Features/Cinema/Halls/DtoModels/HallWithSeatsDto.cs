using Study.Lab3.Storage.Enums.Cinema;

namespace Study.Lab3.Web.Features.Cinema.Halls.DtoModels;

public sealed record HallWithSeatsDto
{
    /// <summary>
    /// Идентификатор зала
    /// </summary>
    public Guid IsnHall { get; init; }

    /// <summary>
    /// Название зала
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Тип зала
    /// </summary>
    public HallType Type { get; init; }

    /// <summary>
    /// Общая вместимость зала
    /// </summary>
    public int Capacity { get; init; }

    /// <summary>
    /// Количество рядов
    /// </summary>
    public int RowsCount { get; init; }

    /// <summary>
    /// Количество мест в ряду
    /// </summary>
    public int SeatsPerRow { get; init; }

    /// <summary>
    /// Активен ли зал
    /// </summary>
    public bool IsActive { get; init; }

    /// <summary>
    /// Места в зале
    /// </summary>
    public SeatItemDto[] Seats { get; init; }

    /// <summary>
    /// Количество запланированных сеансов
    /// </summary>
    public int SessionsCount { get; init; }
}

public sealed record SeatItemDto
{
    /// <summary>
    /// Идентификатор места
    /// </summary>
    public Guid IsnSeat { get; init; }

    /// <summary>
    /// Номер ряда
    /// </summary>
    public int Row { get; init; }

    /// <summary>
    /// Номер места в ряду
    /// </summary>
    public int Number { get; init; }

    /// <summary>
    /// Тип места
    /// </summary>
    public SeatType Type { get; init; }

    /// <summary>
    /// Активно ли место
    /// </summary>
    public bool IsActive { get; init; }
}
