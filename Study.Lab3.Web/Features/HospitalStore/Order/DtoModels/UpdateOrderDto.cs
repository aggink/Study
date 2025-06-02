using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.HospitalStore.Order.DtoModels;

public sealed record UpdateOrderDto
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [Required]
    public Guid IsnOrder { get; init; }

    /// <summary>
    /// Количество товара
    /// </summary>
    [Required]
    [Range(ModelConstants.Order.QuantityMin, ModelConstants.Order.QuantityMax)]
    public int Quantity { get; init; }

    /// <summary>
    /// Дата заказа
    /// </summary>
    [Required]
    public DateTime OrderDate { get; init; }
}
