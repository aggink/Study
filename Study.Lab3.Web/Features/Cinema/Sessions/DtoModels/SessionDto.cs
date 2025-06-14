namespace Study.Lab3.Web.Features.Cinema.Sessions.DtoModels;

public sealed record SessionDto
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
    /// Идентификатор зала
    /// </summary>
    public Guid IsnHall { get; init; }

    /// <summary>
    /// Название зала
    /// </summary>
    public string HallName { get; init; }

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
}