namespace Study.Lab3.Web.Features.HospitalStore.Product.DtoModels;

public sealed record ProductWithDetailsDto
{
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public Guid IsnProduct { get; init; }

    /// <summary>
    /// Название товара
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Категория
    /// </summary>
    public string Category { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; }

    /// <summary>
    /// Общее количество заказов на этот товар
    /// </summary>
    public int TotalOrderedQuantity { get; init; }

    /// <summary>
    /// Последняя дата, когда товар заказывался
    /// </summary>
    public DateTime? LastOrderedDate { get; init; }
}
