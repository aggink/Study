namespace Study.Lab3.Web.Features.HospitalStore.Product.DtoModels;
public sealed record ProductDto
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
    /// Категория товара
    /// </summary>
    public string Category { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; }
}
