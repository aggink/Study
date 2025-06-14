using Study.Lab3.Storage.Enums.Cinema;

namespace Study.Lab3.Web.Features.Cinema.Tickets.DtoModels;

public sealed record TicketDto
{
    /// <summary>
    /// Идентификатор билета
    /// </summary>
    public Guid IsnTicket { get; init; }

    /// <summary>
    /// Идентификатор сеанса
    /// </summary>
    public Guid IsnSession { get; init; }

    /// <summary>
    /// Идентификатор места
    /// </summary>
    public Guid IsnSeat { get; init; }

    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid IsnCustomer { get; init; }

    /// <summary>
    /// Цена билета
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Дата и время покупки
    /// </summary>
    public DateTime PurchaseDate { get; init; }

    /// <summary>
    /// Статус билета
    /// </summary>
    public TicketStatus Status { get; init; }

    /// <summary>
    /// Код билета для проверки
    /// </summary>
    public string TicketCode { get; init; }
}