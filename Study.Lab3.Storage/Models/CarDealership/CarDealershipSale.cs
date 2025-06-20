using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.CarDealership;

/// <summary>
/// Продажа автомобиля
/// </summary>
public class CarDealershipSale
{
    /// <summary>
    /// Идентификатор продажи
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnSale { get; set; }

    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    [ForeignKey(nameof(Customer))]
    public Guid IsnCustomer { get; set; }

    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    [Required]
    [ForeignKey(nameof(Vehicle))]
    public Guid IsnVehicle { get; set; }

    /// <summary>
    /// Дата продажи
    /// </summary>
    [Required]
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Размер скидки
    /// </summary>
    [Range(ModelConstants.CarDealershipSale.MinDiscount, ModelConstants.CarDealershipSale.MaxDiscount)]
    public double Discount { get; set; }

    /// <summary>
    /// Итоговая цена
    /// </summary>
    [Required]
    [Range(ModelConstants.CarDealershipSale.MinFinalPrice, ModelConstants.CarDealershipSale.MaxFinalPrice)]
    public double FinalPrice { get; set; }

    /// <summary>
    /// Клиент
    /// </summary>
    public virtual CarDealershipCustomer Customer { get; set; }

    /// <summary>
    /// Автомобиль
    /// </summary>
    public virtual Vehicle Vehicle { get; set; }
}