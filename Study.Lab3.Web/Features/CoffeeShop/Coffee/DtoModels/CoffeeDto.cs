namespace Study.Lab3.Web.Features.CoffeeShop.Coffee.DtoModels;

/// <summary>
/// DTO кофе
/// </summary>
public sealed record CoffeeDto
{
    /// <summary>
    /// Идентификатор кофе
    /// </summary>
    public Guid IsnCoffee { get; init; }

    /// <summary>
    /// Название кофе
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Описание кофе
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Цена кофе
    /// </summary>
    public double Price { get; init; }

    /// <summary>
    /// Размер порции в мл
    /// </summary>
    public int Size { get; init; }

    /// <summary>
    /// Содержание кофеина в мг
    /// </summary>
    public int? CaffeineContent { get; init; }

    /// <summary>
    /// Доступен ли для заказа
    /// </summary>
    public bool IsAvailable { get; init; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedDate { get; init; }
}