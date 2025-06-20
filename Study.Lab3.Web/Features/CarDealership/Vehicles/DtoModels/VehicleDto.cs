namespace Study.Lab3.Web.Features.CarDealership.Vehicles.DtoModels;

public sealed record VehicleDto
{
    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    public Guid IsnVehicle { get; init; }

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
    /// Цвет
    /// </summary>
    public string Color { get; init; }

    /// <summary>
    /// VIN номер
    /// </summary>
    public string VinNumber { get; init; }

    /// <summary>
    /// Пробег
    /// </summary>
    public int Mileage { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; init; }

    /// <summary>
    /// Доступен ли для продажи
    /// </summary>
    public bool IsAvailable { get; init; }

    /// <summary>
    /// Дата поступления в салон
    /// </summary>
    public DateTime ArrivalDate { get; init; }
}