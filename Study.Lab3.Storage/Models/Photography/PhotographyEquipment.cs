using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Photography;

namespace Study.Lab3.Storage.Models.Photography;

/// <summary>
/// Оборудование фотостудии
/// </summary>
public class PhotographyEquipment
{
    /// <summary>
    /// Идентификатор оборудования
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPhotographyEquipment { get; set; }

    /// <summary>
    /// Название оборудования
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyEquipment.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Тип оборудования
    /// </summary>
    [Required]
    public PhotographyEquipmentType Type { get; set; }

    /// <summary>
    /// Бренд
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyEquipment.Brand)]
    public string Brand { get; set; }

    /// <summary>
    /// Модель
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyEquipment.Model)]
    public string Model { get; set; }

    /// <summary>
    /// Серийный номер
    /// </summary>
    [MaxLength(ModelConstants.PhotographyEquipment.SerialNumber)]
    public string SerialNumber { get; set; }

    /// <summary>
    /// Дата покупки
    /// </summary>
    public DateTime? PurchaseDate { get; set; }

    /// <summary>
    /// Цена покупки
    /// </summary>
    [Range(ModelConstants.PhotographyEquipment.MinPrice, ModelConstants.PhotographyEquipment.MaxPrice)]
    public double? Price { get; set; }

    /// <summary>
    /// Статус оборудования
    /// </summary>
    [Required]
    public PhotographyEquipmentStatus Status { get; set; }

    /// <summary>
    /// Описание/комментарии
    /// </summary>
    [MaxLength(ModelConstants.PhotographyEquipment.Description)]
    public string Description { get; set; }
}