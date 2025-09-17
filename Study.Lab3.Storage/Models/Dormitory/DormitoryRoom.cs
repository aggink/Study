using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Storage.Models.Dormitory;

/// <summary>
/// Комната в общежитии
/// </summary>
public class DormitoryRoom
{
    /// <summary>
    /// Идентификатор комнаты
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Номер комнаты
    /// </summary>
    [Required]
    [StringLength(10)]
    public string RoomNumber { get; set; } = string.Empty;

    /// <summary>
    /// Этаж
    /// </summary>
    [Range(1, 50)]
    public int Floor { get; set; }

    /// <summary>
    /// Площадь комнаты в квадратных метрах
    /// </summary>
    [Range(5.0, 100.0)]
    public double Area { get; set; }

    /// <summary>
    /// Максимальное количество жильцов
    /// </summary>
    [Range(1, 6)]
    public int MaxOccupants { get; set; }

    /// <summary>
    /// Текущее количество жильцов
    /// </summary>
    [Range(0, 6)]
    public int CurrentOccupants { get; set; }

    /// <summary>
    /// Стоимость проживания в месяц
    /// </summary>
    [Range(0, 50000)]
    public decimal MonthlyRent { get; set; }

    /// <summary>
    /// Есть ли балкон
    /// </summary>
    public bool HasBalcony { get; set; }

    /// <summary>
    /// Есть ли собственный санузел
    /// </summary>
    public bool HasPrivateBathroom { get; set; }

    /// <summary>
    /// Описание комнаты
    /// </summary>
    [StringLength(500)]
    public string Description { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
