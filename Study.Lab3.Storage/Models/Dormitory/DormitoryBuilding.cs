using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Storage.Models.Dormitory;

/// <summary>
/// Здание общежития
/// </summary>
public class DormitoryBuilding
{
    /// <summary>
    /// Идентификатор здания
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Название здания
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Адрес здания
    /// </summary>
    [Required]
    [StringLength(200)]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Количество этажей
    /// </summary>
    [Range(1, 50)]
    public int FloorsCount { get; set; }

    /// <summary>
    /// Общее количество комнат
    /// </summary>
    [Range(1, 1000)]
    public int TotalRooms { get; set; }

    /// <summary>
    /// Год постройки
    /// </summary>
    [Range(1900, 2100)]
    public int BuildYear { get; set; }

    /// <summary>
    /// Имя управляющего
    /// </summary>
    [StringLength(100)]
    public string ManagerName { get; set; }

    /// <summary>
    /// Телефон управляющего
    /// </summary>
    [StringLength(20)]
    public string ManagerPhone { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
