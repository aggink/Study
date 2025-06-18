using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.CoffeeShop.Coffee.DtoModels;

/// <summary>
/// DTO для создания кофе
/// </summary>
public class CreateCoffeeDto
{
    /// <summary>
    /// Название кофе
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Coffee.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Описание кофе
    /// </summary>
    [MaxLength(ModelConstants.Coffee.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Цена кофе
    /// </summary>
    [Required]
    [Range(ModelConstants.Coffee.MinPrice, ModelConstants.Coffee.MaxPrice)]
    public double Price { get; set; }

    /// <summary>
    /// Размер порции в мл
    /// </summary>
    [Required]
    [Range(ModelConstants.Coffee.MinSize, ModelConstants.Coffee.MaxSize)]
    public int Size { get; set; }

    /// <summary>
    /// Содержание кофеина в мг
    /// </summary>
    [Range(ModelConstants.Coffee.MinCaffeine, ModelConstants.Coffee.MaxCaffeine)]
    public int? CaffeineContent { get; set; }

    /// <summary>
    /// Доступен ли для заказа
    /// </summary>
    public bool IsAvailable { get; set; } = true;
}