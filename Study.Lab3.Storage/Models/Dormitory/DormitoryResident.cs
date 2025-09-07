using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Storage.Models.Dormitory;

/// <summary>
/// Жилец общежития
/// </summary>
public class DormitoryResident
{
    /// <summary>
    /// Идентификатор жильца
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Имя жильца
    /// </summary>
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Фамилия жильца
    /// </summary>
    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Отчество жильца
    /// </summary>
    [StringLength(50)]
    public string? MiddleName { get; set; }

    /// <summary>
    /// Номер студенческого билета
    /// </summary>
    [Required]
    [StringLength(20)]
    public string StudentId { get; set; } = string.Empty;

    /// <summary>
    /// Группа студента
    /// </summary>
    [Required]
    [StringLength(20)]
    public string StudentGroup { get; set; } = string.Empty;

    /// <summary>
    /// Дата рождения
    /// </summary>
    [Required]
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Email адрес
    /// </summary>
    [StringLength(100)]
    [EmailAddress]
    public string? Email { get; set; }

    /// <summary>
    /// Дата заселения
    /// </summary>
    [Required]
    public DateTime CheckInDate { get; set; }

    /// <summary>
    /// Планируемая дата выселения
    /// </summary>
    public DateTime? PlannedCheckOutDate { get; set; }

    /// <summary>
    /// Фактическая дата выселения
    /// </summary>
    public DateTime? ActualCheckOutDate { get; set; }

    /// <summary>
    /// Дополнительные заметки
    /// </summary>
    [StringLength(500)]
    public string? Notes { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
