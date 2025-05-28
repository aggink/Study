using Study.Lab3.Storage.Enums.Cinema;

namespace Study.Lab3.Web.Features.Cinema.Tickets.DtoModels;

public sealed record TicketWithDetailsDto
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
    /// Название фильма
    /// </summary>
    public string MovieTitle { get; init; }
    
    /// <summary>
    /// Название зала
    /// </summary>
    public string HallName { get; init; }
    
    /// <summary>
    /// Дата и время начала сеанса
    /// </summary>
    public DateTime SessionStartTime { get; init; }
    
    /// <summary>
    /// Дата и время окончания сеанса
    /// </summary>
    public DateTime SessionEndTime { get; init; }
    
    /// <summary>
    /// Идентификатор места
    /// </summary>
    public Guid IsnSeat { get; init; }
    
    /// <summary>
    /// Номер ряда
    /// </summary>
    public int SeatRow { get; init; }
    
    /// <summary>
    /// Номер места в ряду
    /// </summary>
    public int SeatNumber { get; init; }
    
    /// <summary>
    /// Тип места
    /// </summary>
    public SeatType SeatType { get; init; }
    
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid IsnCustomer { get; init; }
    
    /// <summary>
    /// Имя и фамилия клиента
    /// </summary>
    public string CustomerName { get; init; }
    
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