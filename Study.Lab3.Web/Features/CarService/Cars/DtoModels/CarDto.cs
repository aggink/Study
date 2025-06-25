namespace Study.Lab3.Web.Features.CarService.Cars.DtoModels;

public sealed record CarDto
{
    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    public Guid IsnCar { get; init; }
 
    /// <summary>
    /// Идентификатор владельца
    /// </summary>
    public Guid IsnOwner { get; init; }
 
    /// <summary>
    /// Марка автомобиля
    /// </summary>
    public string Brand { get; init; }
 
    /// <summary>
    /// Модель автомобиля
    /// </summary>
    public string Model { get; init; }
 
    /// <summary>
    /// Год выпуска
    /// </summary>
    public int Year { get; init; }
 
    /// <summary>
    /// Государственный номер
    /// </summary>
    public string LicensePlate { get; init; }
 
    /// <summary>
    /// VIN номер
    /// </summary>
    public string VinNumber { get; init; }
 
    /// <summary>
    /// Цвет
    /// </summary>
    public string Color { get; init; }
 
    /// <summary>
    /// Пробег в километрах
    /// </summary>
    public int Mileage { get; init; }
}