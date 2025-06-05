using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.OrderItems.DtoModels;

public sealed record CreateOrderItemDto
{
    /// <summary>
    /// Идентификатор позиции меню
    /// </summary>
    [Required]
    public Guid IsnMenuItem { get; init; }

    /// <summary>
    /// Количество
    /// </summary>
    [Required]
    [Range(ModelConstants.OrderItem.MinQuantity, ModelConstants.OrderItem.MaxQuantity)]
    public int Quantity { get; init; } = 1;

    /// <summary>
    /// Особые пожелания к блюду
    /// </summary>
    [MaxLength(ModelConstants.OrderItem.SpecialRequests)]
    public string SpecialRequests { get; init; }
}
