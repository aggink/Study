using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Fitness;

namespace Study.Lab3.Storage.Models.Fitness;

/// <summary>
/// Оборудование фитнес-центра
/// </summary>
public class FitnessEquipment
{
    /// <summary>
    /// Идентификатор оборудования
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnEquipment { get; set; }

    /// <summary>
    /// Название оборудования
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessEquipment.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Производитель
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessEquipment.Manufacturer)]
    public string Manufacturer { get; set; }

    /// <summary>
    /// Модель
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessEquipment.Model)]
    public string Model { get; set; }

    /// <summary>
    /// Серийный номер
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessEquipment.SerialNumber)]
    public string SerialNumber { get; set; }

    /// <summary>
    /// Тип оборудования
    /// </summary>
    [Required]
    public EquipmentType Type { get; set; }

    /// <summary>
    /// Дата покупки
    /// </summary>
    [Required]
    public DateTime PurchaseDate { get; set; }

    /// <summary>
    /// Цена покупки
    /// </summary>
    [Required]
    [Range(ModelConstants.FitnessEquipment.MinPrice, ModelConstants.FitnessEquipment.MaxPrice)]
    public decimal PurchasePrice { get; set; }

    /// <summary>
    /// Статус оборудования
    /// </summary>
    [Required]
    public EquipmentStatus Status { get; set; }

    /// <summary>
    /// Дата последнего обслуживания
    /// </summary>
    public DateTime? LastMaintenanceDate { get; set; }

    /// <summary>
    /// Описание/Примечания
    /// </summary>
    [MaxLength(ModelConstants.FitnessEquipment.Description)]
    public string Description { get; set; }
}