using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Workshop;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.ServiceOrders.DtoModels;

public sealed record CreateServiceOrderDto
{
    /// <summary>
    /// Идентификатор мастера
    /// </summary>
    [Required]
    public Guid IsnMaster { get; init; }

    /// <summary>
    /// Идентификатор услуги
    /// </summary>
    [Required]
    public Guid IsnService { get; init; }

    /// <summary>
    /// Имя клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.ServiceOrder.CustomerName)]
    public string CustomerName { get; init; }

    /// <summary>
    /// Телефон клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.ServiceOrder.CustomerPhone)]
    public string CustomerPhone { get; init; }

    /// <summary>
    /// Дата создания заказа
    /// </summary>
    public DateTime OrderDate { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Статус заказа
    /// </summary>
    [Required]
    public OrderStatus Status { get; init; } = OrderStatus.Pending;

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
