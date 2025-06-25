namespace Study.Lab3.Web.Features.CarDealership.Sales.DtoModels;

public sealed record CarDealershipSaleDto
{
    /// <summary>
    /// Идентификатор продажи
    /// </summary>
    public Guid IsnSale { get; init; }

    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid IsnCustomer { get; init; }

    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    public Guid IsnVehicle { get; init; }

    /// <summary>
    /// Дата продажи
    /// </summary>
    public DateTime SaleDate { get; init; }

    /// <summary>
    /// Размер скидки
    /// </summary>
    public double Discount { get; init; }

    /// <summary>
    /// Итоговая цена
    /// </summary>
    public double FinalPrice { get; init; }
}