using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.HospitalStore.Product.DtoModels;

public sealed record UpdateProductDto
{
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    [Required]
    public Guid IsnProduct { get; init; }

    /// <summary>
    /// Название товара
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Product.NameMaxLength)]
    public string Name { get; init; }

    /// <summary>
    /// Категория товара
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Product.CategoryMaxLength)]
    public string Category { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    [Required]
    [Range(ModelConstants.Product.PriceMin, ModelConstants.Product.PriceMax)]
    public int Price { get; init; }
}
