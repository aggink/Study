namespace Study.Lab3.Storage.Enums.PetShop;

/// <summary>
/// Статус животного
/// </summary>
public enum PetStatus
{
    /// <summary>
    /// Доступно для продажи
    /// </summary>
    Available = 0,
    
    /// <summary>
    /// Зарезервировано
    /// </summary>
    Reserved = 1,
    
    /// <summary>
    /// Продано
    /// </summary>
    Sold = 2,
    
    /// <summary>
    /// На лечении
    /// </summary>
    UnderTreatment = 3
}