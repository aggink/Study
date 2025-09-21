using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.CarDealership.Sales.DtoModels;

public sealed record UpdateCarDealershipSaleDto
{
    /// <summary>
    /// Идентификатор продажи
    /// </summary>
    [Required]
    public Guid IsnSale { get; init; }
    
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    public Guid IsnCustomer { get; init; }

    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    [Required]
    public Guid IsnVehicle { get; init; }

    /// <summary>
    /// Размер скидки
    /// </summary>
    [Range(ModelConstants.CarDealershipSale.MinDiscount, ModelConstants.CarDealershipSale.MaxDiscount)]
    public double Discount { get; init; }

    /// <summary>
    /// Итоговая цена
    /// </summary>
    [Required]
    [Range(ModelConstants.CarDealershipSale.MinFinalPrice, ModelConstants.CarDealershipSale.MaxFinalPrice)]
    public double FinalPrice { get; init; }
}