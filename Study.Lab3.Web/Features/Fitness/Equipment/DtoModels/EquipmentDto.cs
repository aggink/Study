using Study.Lab3.Storage.Enums.Fitness;

namespace Study.Lab3.Web.Features.Fitness.Equipment.DtoModels;

public sealed record EquipmentDto
{
    /// <summary>
    /// Идентификатор оборудования
    /// </summary>
    public Guid IsnEquipment { get; init; }

    /// <summary>
    /// Название оборудования
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Производитель
    /// </summary>
    public string Manufacturer { get; init; }

    /// <summary>
    /// Модель
    /// </summary>
    public string Model { get; init; }

    /// <summary>
    /// Серийный номер
    /// </summary>
    public string SerialNumber { get; init; }

    /// <summary>
    /// Тип оборудования
    /// </summary>
    public EquipmentType Type { get; init; }

    /// <summary>
    /// Дата покупки
    /// </summary>
    public DateTime PurchaseDate { get; init; }

    /// <summary>
    /// Цена покупки
    /// </summary>
    public decimal PurchasePrice { get; init; }

    /// <summary>
    /// Статус оборудования
    /// </summary>
    public EquipmentStatus Status { get; init; }

    /// <summary>
    /// Дата последнего обслуживания
    /// </summary>
    public DateTime? LastMaintenanceDate { get; init; }

    /// <summary>
    /// Описание/Примечания
    /// </summary>
    public string Description { get; init; }
}
