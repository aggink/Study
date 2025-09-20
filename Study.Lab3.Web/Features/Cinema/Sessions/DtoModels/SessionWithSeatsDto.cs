using Study.Lab3.Storage.Enums.Cinema;

namespace Study.Lab3.Web.Features.Cinema.Sessions.DtoModels;

public sealed record SessionWithSeatsDto
{
    /// <summary>
    /// Идентификатор сеанса
    /// </summary>
    public Guid IsnSession { get; init; }

    /// <summary>
    /// Идентификатор фильма
    /// </summary>
    public Guid IsnMovie { get; init; }

    /// <summary>
    /// Название фильма
    /// </summary>
    public string MovieTitle { get; init; }

    /// <summary>
    /// Продолжительность фильма
    /// </summary>
    public int MovieDuration { get; init; }

    /// <summary>
    /// Идентификатор зала
    /// </summary>
    public Guid IsnHall { get; init; }

    /// <summary>
    /// Название зала
    /// </summary>
    public string HallName { get; init; }

    /// <summary>
    /// Тип зала
    /// </summary>
    public string HallType { get; init; }

    /// <summary>
    /// Время начала сеанса
    /// </summary>
    public DateTime StartTime { get; init; }

    /// <summary>
    /// Время окончания сеанса
    /// </summary>
    public DateTime EndTime { get; init; }

    /// <summary>
    /// Базовая цена билета
    /// </summary>
    public decimal BasePrice { get; init; }

    /// <summary>
    /// Активен ли сеанс
    /// </summary>
    public bool IsActive { get; init; }

    /// <summary>
    /// Места в зале с информацией о доступности
    /// </summary>
    public SessionSeatDto[] Seats { get; init; }

    /// <summary>
    /// Количество свободных мест
    /// </summary>
    public int AvailableSeatsCount { get; init; }

    /// <summary>
    /// Количество проданных билетов
    /// </summary>
    public int SoldSeatsCount { get; init; }
}

public sealed record SessionSeatDto
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
    /// Доступно ли место для бронирования
    /// </summary>
    public bool IsAvailable { get; init; }

    /// <summary>
    /// Идентификатор билета, если место забронировано
    /// </summary>
    public Guid? IsnTicket { get; init; }
}

