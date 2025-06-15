namespace Study.Lab3.Storage.Enums.Photography;

/// <summary>
/// Статус оборудования
/// </summary>
public enum PhotographyEquipmentStatus
{
    /// <summary>
    /// Исправно
    /// </summary>
    Working = 0,

    /// <summary>
    /// В ремонте
    /// </summary>
    InRepair = 1,

    /// <summary>
    /// Неисправно
    /// </summary>
    Broken = 2,

    /// <summary>
    /// На обслуживании
    /// </summary>
    InService = 3,

    /// <summary>
    /// Выведено из эксплуатации
    /// </summary>
    Retired = 4
}