using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Orders.DtoModels;

public sealed record UpdateOrderDto
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [Required]
    public Guid IsnOrder { get; init; }

    /// <summary>
    /// Имя клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.RestaurantOrder.CustomerName)]
    public string CustomerName { get; init; }

    /// <summary>
    /// Телефон клиента
    /// </summary>
    [MaxLength(ModelConstants.RestaurantOrder.CustomerPhone)]
    public string CustomerPhone { get; init; }

    /// <summary>
    /// Номер стола
    /// </summary>
    [Range(ModelConstants.RestaurantOrder.MinTableNumber, ModelConstants.RestaurantOrder.MaxTableNumber)]
    public int? TableNumber { get; init; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.RestaurantOrder.Status)]
    public string Status { get; init; }
}