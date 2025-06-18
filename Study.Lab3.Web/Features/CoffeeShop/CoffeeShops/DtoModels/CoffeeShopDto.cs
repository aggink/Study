namespace Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.DtoModels;

/// <summary>
/// DTO кофейни
/// </summary>
public class CoffeeShopDto
{
    /// <summary>
    /// Идентификатор кофейни
    /// </summary>
    public Guid IsnCoffeeShop { get; set; }

    /// <summary>
    /// Название кофейни
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Адрес кофейни
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Телефон кофейни
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Email кофейни
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Время работы
    /// </summary>
    public string WorkingHours { get; set; }

    /// <summary>
    /// Рейтинг кофейни
    /// </summary>
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