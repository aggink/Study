using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.CoffeeShop.Coffee.DtoModels;

/// <summary>
/// DTO для обновления кофе
/// </summary>
public sealed record UpdateCoffeeDto
{
    /// <summary>
    /// Идентификатор кофе
    /// </summary>
    [Required]
    public Guid IsnCoffee { get; init; }

    /// <summary>
    /// Название кофе
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Coffee.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Описание кофе
    /// </summary>
    [MaxLength(ModelConstants.Coffee.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Цена кофе
    /// </summary>
    [Required]
    [Range(ModelConstants.Coffee.MinPrice, ModelConstants.Coffee.MaxPrice)]
    public double Price { get; init; }

    /// <summary>
    /// Размер порции в мл
    /// </summary>
    [Required]
    [Range(ModelConstants.Coffee.MinSize, ModelConstants.Coffee.MaxSize)]
    public int Size { get; init; }

    /// <summary>
    /// Содержание кофеина в мг
    /// </summary>
    [Range(ModelConstants.Coffee.MinCaffeine, ModelConstants.Coffee.MaxCaffeine)]
    public int? CaffeineContent { get; init; }

    /// <summary>
    /// Доступен ли для заказа
    /// </summary>
    public bool IsAvailable { get; init; }
}