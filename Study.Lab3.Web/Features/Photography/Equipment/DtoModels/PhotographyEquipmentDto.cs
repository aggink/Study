using Study.Lab3.Storage.Enums.Photography;

namespace Study.Lab3.Web.Features.Photography.Equipment.DtoModels;

public sealed record PhotographyEquipmentDto
{
    /// <summary>
    /// Идентификатор оборудования
    /// </summary>
    public Guid IsnPhotographyEquipment { get; init; }

    /// <summary>
    /// Название оборудования
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Тип оборудования
    /// </summary>
    public PhotographyEquipmentType Type { get; init; }

    /// <summary>
    /// Бренд
    /// </summary>
    public string Brand { get; init; }

    /// <summary>
    /// Модель
    /// </summary>
    public string Model { get; init; }

    /// <summary>
    /// Серийный номер
    /// </summary>
    public string SerialNumber { get; init; }

    /// <summary>
    /// Дата покупки
    /// </summary>
    public DateTime? PurchaseDate { get; init; }

    /// <summary>
    /// Цена покупки
    /// </summary>
    public double? Price { get; init; }

    /// <summary>
    /// Статус оборудования
    /// </summary>
    public PhotographyEquipmentStatus Status { get; init; }

    /// <summary>
    /// Описание/комментарии
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Полное название оборудования
    /// </summary>
    public string FullName => $"{Brand} {Model} ({Name})";
}