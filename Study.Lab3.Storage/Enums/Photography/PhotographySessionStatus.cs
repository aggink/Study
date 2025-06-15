namespace Study.Lab3.Storage.Enums.Photography;

/// <summary>
/// Статус фотосессии
/// </summary>
public enum PhotographySessionStatus
{
    /// <summary>
    /// Запланирована
    /// </summary>
    Scheduled = 0,

    /// <summary>
    /// В процессе
    /// </summary>
    InProgress = 1,

    /// <summary>
    /// Завершена
    /// </summary>
    Completed = 2,

    /// <summary>
    /// Отменена
    /// </summary>
    Cancelled = 3,

    /// <summary>
    /// Перенесена
    /// </summary>
    Postponed = 4,

    /// <summary>
    /// Обработка фото
    /// </summary>
    Processing = 5,

    /// <summary>
    /// Готова к выдаче
    /// </summary>
    ReadyForDelivery = 6
}