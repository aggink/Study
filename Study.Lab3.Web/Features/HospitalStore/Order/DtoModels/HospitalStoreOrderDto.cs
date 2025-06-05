namespace Study.Lab3.Web.Features.HospitalStore.Order.DtoModels;

/// <summary>
/// DTO для отображения информации о заказе
/// </summary>
public sealed record HospitalStoreOrderDto
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid IsnOrder { get; init; }

    /// <summary>
    /// Идентификатор пациента
    /// </summary>
    public Guid IsnPatient { get; init; }

    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public Guid IsnProduct { get; init; }

    /// <summary>
    /// Количество товара
    /// </summary>
    public int Quantity { get; init; }
}
