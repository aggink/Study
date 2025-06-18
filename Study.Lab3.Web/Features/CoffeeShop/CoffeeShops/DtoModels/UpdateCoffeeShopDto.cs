using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.DtoModels;

/// <summary>
/// DTO для обновления кофейни
/// </summary>
public class UpdateCoffeeShopDto
{
    /// <summary>
    /// Идентификатор кофейни
    /// </summary>
    [Required]
    public Guid IsnCoffeeShop { get; set; }

    /// <summary>
    /// Название кофейни
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.CoffeeShop.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Адрес кофейни
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.CoffeeShop.Address)]
    public string Address { get; set; }

    /// <summary>
    /// Телефон кофейни
    /// </summary>
    [MaxLength(ModelConstants.CoffeeShop.Phone)]
    public string Phone { get; set; }

    /// <summary>
    /// Email кофейни
    /// </summary>
    [MaxLength(ModelConstants.CoffeeShop.Email)]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Время работы
    /// </summary>
    [MaxLength(ModelConstants.CoffeeShop.WorkingHours)]
    public string WorkingHours { get; set; }

    /// <summary>
    /// Рейтинг кофейни
    /// </summary>
    [Range(ModelConstants.CoffeeShop.MinRating, ModelConstants.CoffeeShop.MaxRating)]
    public double? Rating { get; set; }

    /// <summary>
    /// Дата открытия
    /// </summary>
    public DateTime OpeningDate { get; set; }

    /// <summary>
    /// Активна ли кофейня
    /// </summary>
    public bool IsActive { get; set; }
}