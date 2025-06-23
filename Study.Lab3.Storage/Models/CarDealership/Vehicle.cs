using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.CarDealership;

/// <summary>
/// Автомобиль в автосалоне
/// </summary>
public class Vehicle
{
    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnVehicle { get; set; }

    /// <summary>
    /// Марка автомобиля
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Vehicle.Brand)]
    public string Brand { get; set; }

    /// <summary>
    /// Модель автомобиля
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Vehicle.Model)]
    public string Model { get; set; }

    /// <summary>
    /// Год выпуска
    /// </summary>
    [Required]
    [Range(ModelConstants.Vehicle.MinYear, ModelConstants.Vehicle.MaxYear)]
    public int Year { get; set; }

    /// <summary>
    /// Цвет
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Vehicle.Color)]
    public string Color { get; set; }

    /// <summary>
    /// VIN номер
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Vehicle.VinNumber)]
    public string VinNumber { get; set; }

    /// <summary>
    /// Пробег
    /// </summary>
    [Range(ModelConstants.Vehicle.MinMileage, ModelConstants.Vehicle.MaxMileage)]
    public int Mileage { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    [Required]
    [Range(ModelConstants.Vehicle.MinPrice, ModelConstants.Vehicle.MaxPrice)]
    public double Price { get; set; }

    /// <summary>
    /// Доступен ли для продажи
    /// </summary>
    [Required]
    public bool IsAvailable { get; set; }

    /// <summary>
    /// Дата поступления в салон
    /// </summary>
    [Required]
    public DateTime ArrivalDate { get; set; }

    /// <summary>
    /// Продажи автомобиля
    /// </summary>
    [InverseProperty(nameof(CarDealershipSale.Vehicle))]
    public virtual ICollection<CarDealershipSale> Sales { get; set; }
}