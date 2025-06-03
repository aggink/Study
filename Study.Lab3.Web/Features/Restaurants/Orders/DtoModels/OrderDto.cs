namespace Study.Lab3.Web.Features.Restaurants.Orders.DtoModels;

public sealed record OrderDto
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid IsnOrder { get; init; }

    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    public Guid IsnRestaurant { get; init; }

    /// <summary>
    /// Номер заказа
    /// </summary>
    public string OrderNumber { get; init; }

    /// <summary>
    /// Имя клиента
    /// </summary>
    public string CustomerName { get; init; }

    /// <summary>
    /// Телефон клиента
    /// </summary>
    public string CustomerPhone { get; init; }

    /// <summary>
    /// Номер стола
    /// </summary>
    public int? TableNumber { get; init; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    public string Status { get; init; }

    /// <summary>
    /// Общая сумма заказа
    /// </summary>
    public double TotalAmount { get; init; }

    /// <summary>
    /// Дата создания заказа
    /// </summary>
    public DateTime CreatedDate { get; init; }

    /// <summary>
    /// Дата завершения заказа
    /// </summary>
    public DateTime? CompletedDate { get; init; }
}
