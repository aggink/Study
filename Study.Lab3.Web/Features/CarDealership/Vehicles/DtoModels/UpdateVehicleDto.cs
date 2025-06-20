using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.CarDealership.Vehicles.DtoModels;

public sealed record UpdateVehicleDto
{
    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    [Required]
    public Guid IsnVehicle { get; init; }
    
    /// <summary>
    /// Марка автомобиля
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Vehicle.Brand)]
    public string Brand { get; init; }

    /// <summary>
    /// Модель автомобиля
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Vehicle.Model)]
    public string Model { get; init; }

    /// <summary>
    /// Год выпуска
    /// </summary>
    [Required]
    [Range(ModelConstants.Vehicle.MinYear, ModelConstants.Vehicle.MaxYear)]
    public int Year { get; init; }

    /// <summary>
    /// Цвет
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Vehicle.Color)]
    public string Color { get; init; }

    /// <summary>
    /// VIN номер
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Vehicle.VinNumber)]
    public string VinNumber { get; init; }

    /// <summary>
    /// Пробег
    /// </summary>
    [Range(ModelConstants.Vehicle.MinMileage, ModelConstants.Vehicle.MaxMileage)]
    public int Mileage { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    [Required]
    [Range(ModelConstants.Vehicle.MinPrice, ModelConstants.Vehicle.MaxPrice)]
    public double Price { get; init; }

    /// <summary>
    /// Доступен ли для продажи
    /// </summary>
    [Required]
    public bool IsAvailable { get; init; }
}