using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Photography;

namespace Study.Lab3.Web.Features.Photography.Equipment.DtoModels;

public sealed record CreatePhotographyEquipmentDto
{
    /// <summary>
    /// Название оборудования
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyEquipment.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Тип оборудования
    /// </summary>
    [Required]
    public PhotographyEquipmentType Type { get; init; }

    /// <summary>
    /// Бренд
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyEquipment.Brand)]
    public string Brand { get; init; }

    /// <summary>
    /// Модель
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyEquipment.Model)]
    public string Model { get; init; }

    /// <summary>
    /// Серийный номер
    /// </summary>
    [MaxLength(ModelConstants.PhotographyEquipment.SerialNumber)]
    public string SerialNumber { get; init; }

    /// <summary>
    /// Дата покупки
    /// </summary>
    public DateTime? PurchaseDate { get; init; }

    /// <summary>
    /// Цена покупки
    /// </summary>
    [Range(ModelConstants.PhotographyEquipment.MinPrice, ModelConstants.PhotographyEquipment.MaxPrice)]
    public double? Price { get; init; }

    /// <summary>
    /// Статус оборудования
    /// </summary>
    [Required]
    public PhotographyEquipmentStatus Status { get; init; } = PhotographyEquipmentStatus.Working;

    /// <summary>
    /// Описание/комментарии
    /// </summary>
    [MaxLength(ModelConstants.PhotographyEquipment.Description)]
    public string Description { get; init; }
}
