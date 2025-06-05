using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Workshop;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.ServiceOrders.DtoModels;

public sealed record UpdateServiceOrderDto
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [Required]
    public Guid IsnServiceOrder { get; init; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    [Required]
    public OrderStatus Status { get; init; }

    /// <summary>
    /// Описание проблемы от клиента
    /// </summary>
    [MaxLength(ModelConstants.ServiceOrder.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Итоговая стоимость
    /// </summary>
    [Range(ModelConstants.ServiceOrder.MinTotalPrice, ModelConstants.ServiceOrder.MaxTotalPrice)]
    public double? TotalPrice { get; init; }
}
