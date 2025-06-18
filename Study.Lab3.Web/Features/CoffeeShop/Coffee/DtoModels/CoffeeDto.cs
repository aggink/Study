namespace Study.Lab3.Web.Features.CoffeeShop.Coffee.DtoModels;

/// <summary>
/// DTO кофе
/// </summary>
public class CoffeeDto
{
    /// <summary>
    /// Идентификатор кофе
    /// </summary>
    public Guid IsnCoffee { get; set; }

    /// <summary>
    /// Название кофе
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание кофе
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Цена кофе
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Размер порции в мл
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// Содержание кофеина в мг
    /// </summary>
    public int? CaffeineContent { get; set; }

    /// <summary>
    /// Доступен ли для заказа
    /// </summary>
    public bool IsAvailable { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedDate { get; set; }
}