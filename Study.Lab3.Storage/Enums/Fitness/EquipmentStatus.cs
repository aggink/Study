namespace Study.Lab3.Storage.Enums.Fitness;

/// <summary>
/// Статус оборудования
/// </summary>
public enum EquipmentStatus
{
    /// <summary>
    /// Работает
    /// </summary>
    Working = 0,

    /// <summary>
    /// На обслуживании
    /// </summary>
    Maintenance = 1,

    /// <summary>
    /// Сломано
    /// </summary>
    Broken = 2,

    /// <summary>
    /// Списано
    /// </summary>
    Retired = 3
}