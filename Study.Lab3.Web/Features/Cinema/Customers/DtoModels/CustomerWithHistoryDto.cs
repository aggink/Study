namespace Study.Lab3.Web.Features.Cinema.Customers.DtoModels;

public sealed record CustomerWithHistoryDto
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid IsnCustomer { get; init; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; init; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; init; }
    
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; init; }
    
    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; init; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; init; }
    
    /// <summary>
    /// Дата регистрации
    /// </summary>
    public DateTime RegistrationDate { get; init; }
    
    /// <summary>
    /// Активен ли клиент
    /// </summary>
    public bool IsActive { get; init; }
    
    /// <summary>
    /// История покупок билетов
    /// </summary>
    public TicketHistoryItemDto[] TicketHistory { get; init; }
    
    /// <summary>
    /// Общее количество купленных билетов
    /// </summary>
    public int TotalTicketsBought { get; init; }
    
    /// <summary>
    /// Общая сумма потраченных средств
    /// </summary>
    public decimal TotalSpent { get; init; }
}

public sealed record TicketHistoryItemDto
{
    /// <summary>
    /// Идентификатор билета
    /// </summary>
    public Guid IsnTicket { get; init; }
    
    /// <summary>
    /// Название фильма
    /// </summary>
    public string MovieTitle { get; init; }
    
    /// <summary>
    /// Название зала
    /// </summary>
    public string HallName { get; init; }
    
    /// <summary>
    /// Дата и время сеанса
    /// </summary>
    public DateTime SessionDateTime { get; init; }
    
    /// <summary>
    /// Информация о месте (ряд и номер)
    /// </summary>
    public string SeatInfo { get; init; }
    
    /// <summary>
    /// Цена билета
    /// </summary>
    public decimal Price { get; init; }
    
    /// <summary>
    /// Дата покупки
    /// </summary>
    public DateTime PurchaseDate { get; init; }
    
    /// <summary>
    /// Статус билета
    /// </summary>
    public string Status { get; init; }
}