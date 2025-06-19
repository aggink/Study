namespace Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.DtoModels;

/// <summary>
/// DTO кофейни
/// </summary>
public sealed record CoffeeShopDto
{
    /// <summary>
    /// Идентификатор кофейни
    /// </summary>
    public Guid IsnCoffeeShop { get; init; }

    /// <summary>
    /// Название кофейни
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Адрес кофейни
    /// </summary>
    public string Address { get; init; }

    /// <summary>
    /// Телефон кофейни
    /// </summary>
    public string Phone { get; init; }

    /// <summary>
    /// Email кофейни
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// Время работы
    /// </summary>
    public string WorkingHours { get; init; }

    /// <summary>
    /// Рейтинг кофейни
    /// </summary>
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