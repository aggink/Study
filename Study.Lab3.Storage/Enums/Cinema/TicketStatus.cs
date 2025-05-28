namespace Study.Lab3.Storage.Enums.Cinema;

/// <summary>
/// Статус билета
/// </summary>
public enum TicketStatus
{
    /// <summary>
    /// Активный билет
    /// </summary>
    Active = 0,

    /// <summary>
    /// Использованный билет
    /// </summary>
    Used = 1,

    /// <summary>
    /// Отменённый билет
    /// </summary>
    Cancelled = 2,

    /// <summary>
    /// Просроченный билет
    /// </summary>
    Expired = 3
}
