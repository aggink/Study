using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Orders.DtoModels;

public sealed record UpdateOrderStatusDto
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [Required]
    public Guid IsnOrder { get; init; }

    /// <summary>
    /// Новый статус заказа
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.RestaurantOrder.Status)]
    public string Status { get; init; }
}