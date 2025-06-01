using Study.Lab3.Storage.Constants;
using Study.Lab3.Web.Features.Restaurants.OrderItems.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Orders.DtoModels;

public sealed record CreateOrderDto
{
    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    [Required]
    public Guid IsnRestaurant { get; init; }

    /// <summary>
    /// Имя клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Order.CustomerName)]
    public string CustomerName { get; init; }

    /// <summary>
    /// Телефон клиента
    /// </summary>
    [MaxLength(ModelConstants.Order.CustomerPhone)]
    public string CustomerPhone { get; init; }

    /// <summary>
    /// Номер стола
    /// </summary>
    [Range(ModelConstants.Order.MinTableNumber, ModelConstants.Order.MaxTableNumber)]
    public int? TableNumber { get; init; }

    /// <summary>
    /// Позиции заказа
    /// </summary>
    public CreateOrderItemDto[] OrderItems { get; init; }
}
