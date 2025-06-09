using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Fitness;

namespace Study.Lab3.Web.Features.Fitness.Equipment.DtoModels;

public sealed record CreateEquipmentDto
{
    /// <summary>
    /// Название оборудования
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessEquipment.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Производитель
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessEquipment.Manufacturer)]
    public string Manufacturer { get; init; }

    /// <summary>
    /// Модель
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessEquipment.Model)]
    public string Model { get; init; }

    /// <summary>
    /// Серийный номер
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessEquipment.SerialNumber)]
    public string SerialNumber { get; init; }

    /// <summary>
    /// Тип оборудования
    /// </summary>
    [Required]
    public EquipmentType Type { get; init; }

    /// <summary>
    /// Дата покупки
    /// </summary>
    [Required]
    public DateTime PurchaseDate { get; init; }

    /// <summary>
    /// Цена покупки
    /// </summary>
    [Required]
    [Range(ModelConstants.FitnessEquipment.MinPrice, ModelConstants.FitnessEquipment.MaxPrice)]
    public decimal PurchasePrice { get; init; }

    /// <summary>
    /// Статус оборудования
    /// </summary>
    [Required]
    public EquipmentStatus Status { get; init; } = EquipmentStatus.Working;

    /// <summary>
    /// Дата последнего обслуживания
    /// </summary>
    public DateTime? LastMaintenanceDate { get; init; }

    /// <summary>
    /// Описание/Примечания
    /// </summary>
    [MaxLength(ModelConstants.FitnessEquipment.Description)]
    public string Description { get; init; }
}
