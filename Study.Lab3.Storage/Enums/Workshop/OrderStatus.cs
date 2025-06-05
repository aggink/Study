namespace Study.Lab3.Storage.Enums.Workshop;

/// <summary>
/// Статус заказа
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// Ожидает выполнения
    /// </summary>
    Pending = 0,

    /// <summary>
    /// В процессе выполнения
    /// </summary>
    InProgress = 1,

    /// <summary>
    /// Выполнен
    /// </summary>
    Completed = 2,

    /// <summary>
    /// Отменен
    /// </summary>
    Cancelled = 3
}