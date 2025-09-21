using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.CarService.Cars.DtoModels;

public sealed record UpdateCarDto
{
    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    [Required]
    public Guid IsnCar { get; init; }
 
    /// <summary>
    /// Марка автомобиля
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Car.Brand)]
    public string Brand { get; init; }
 
    /// <summary>
    /// Модель автомобиля
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Car.Model)]
    public string Model { get; init; }
 
    /// <summary>
    /// Год выпуска
    /// </summary>
    [Required]
    [Range(ModelConstants.Car.MinYear, ModelConstants.Car.MaxYear)]
    public int Year { get; init; }
 
    /// <summary>
    /// Государственный номер
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Car.LicensePlate)]
    public string LicensePlate { get; init; }
 
    /// <summary>
    /// VIN номер
    /// </summary>
    [MaxLength(ModelConstants.Car.VinNumber)]
    public string VinNumber { get; init; }
 
    /// <summary>
    /// Цвет
    /// </summary>
    [MaxLength(ModelConstants.Car.Color)]
    public string Color { get; init; }
 
    /// <summary>
    /// Пробег в километрах
    /// </summary>
    [Range(ModelConstants.Car.MinMileage, int.MaxValue)]
    public int Mileage { get; init; }
}