namespace Study.Lab3.Web.Features.Restaurants.OrderItems.DtoModels;

public sealed record OrderItemDto
{
    /// <summary>
    /// Идентификатор позиции заказа
    /// </summary>
    public Guid IsnOrderItem { get; init; }

    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid IsnOrder { get; init; }

    /// <summary>
    /// Идентификатор позиции меню
    /// </summary>
    public Guid IsnMenuItem { get; init; }

    /// <summary>
    /// Название блюда
    /// </summary>
    public string MenuItemName { get; init; }

    /// <summary>
    /// Количество
    /// </summary>
    public int Quantity { get; init; }

    /// <summary>
    /// Цена за единицу
    /// </summary>
    public double UnitPrice { get; init; }

    /// <summary>
    /// Общая стоимость позиции
    /// </summary>
    public double TotalPrice { get; init; }

    /// <summary>
    /// Особые пожелания к блюду
    /// </summary>
    public string SpecialRequests { get; init; }
}
