using Study.Lab3.Storage.Enums.Workshop;

namespace Study.Lab3.Web.Features.Workshop.ServiceOrders.DtoModels;

public sealed record ServiceOrderDto
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid IsnServiceOrder { get; init; }

    /// <summary>
    /// Идентификатор мастера
    /// </summary>
    public Guid IsnMaster { get; init; }

    /// <summary>
    /// Идентификатор услуги
    /// </summary>
    public Guid IsnService { get; init; }

    /// <summary>
    /// Имя клиента
    /// </summary>
    public string CustomerName { get; init; }

    /// <summary>
    /// Телефон клиента
    /// </summary>
    public string CustomerPhone { get; init; }

    /// <summary>
    /// Дата создания заказа
    /// </summary>
    public DateTime OrderDate { get; init; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    public OrderStatus Status { get; init; }

    /// <summary>
    /// Описание проблемы от клиента
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Итоговая стоимость
    /// </summary>
    public double? TotalPrice { get; init; }
}
