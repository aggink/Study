using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.DtoModels;

/// <summary>
/// DTO для обновления кофейни
/// </summary>
public sealed record UpdateCoffeeShopDto
{
    /// <summary>
    /// Идентификатор кофейни
    /// </summary>
    [Required]
    public Guid IsnCoffeeShop { get; init; }

    /// <summary>
    /// Название кофейни
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.CoffeeShop.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Адрес кофейни
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.CoffeeShop.Address)]
    public string Address { get; init; }

    /// <summary>
    /// Телефон кофейни
    /// </summary>
    [MaxLength(ModelConstants.CoffeeShop.Phone)]
    public string Phone { get; init; }

    /// <summary>
    /// Email кофейни
    /// </summary>
    [MaxLength(ModelConstants.CoffeeShop.Email)]
    [EmailAddress]
    public string Email { get; init; }

    /// <summary>
    /// Время работы
    /// </summary>
    [MaxLength(ModelConstants.CoffeeShop.WorkingHours)]
    public string WorkingHours { get; init; }

    /// <summary>
    /// Рейтинг кофейни
    /// </summary>
    [Range(ModelConstants.CoffeeShop.MinRating, ModelConstants.CoffeeShop.MaxRating)]
    public double? Rating { get; init; }

    /// <summary>
    /// Дата открытия
    /// </summary>
    public DateTime OpeningDate { get; init; }

    /// <summary>
    /// Активна ли кофейня
    /// </summary>
    public bool IsActive { get; init; }
}