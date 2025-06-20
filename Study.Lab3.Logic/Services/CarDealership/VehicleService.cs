using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarDealership;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarDealership;

namespace Study.Lab3.Logic.Services.CarDealership;

/// <summary>
/// Сервис для работы с автомобилями
/// </summary>
public sealed class VehicleService : IVehicleService
{
    public async Task CreateOrUpdateVehicleValidateAndThrowAsync(
        DataContext dataContext,
        Vehicle vehicle,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(vehicle.Brand))
            throw new BusinessLogicException("Марка автомобиля не может быть пустой");

        if (string.IsNullOrWhiteSpace(vehicle.Model))
            throw new BusinessLogicException("Модель автомобиля не может быть пустой");

        if (string.IsNullOrWhiteSpace(vehicle.Color))
            throw new BusinessLogicException("Цвет автомобиля не может быть пустым");

        if (string.IsNullOrWhiteSpace(vehicle.VinNumber))
            throw new BusinessLogicException("VIN номер не может быть пустым");

        // Проверка года выпуска
        if (vehicle.Year < ModelConstants.Vehicle.MinYear || vehicle.Year > ModelConstants.Vehicle.MaxYear)
            throw new BusinessLogicException($"Год выпуска должен быть между {ModelConstants.Vehicle.MinYear} и {ModelConstants.Vehicle.MaxYear}");

        // Проверка пробега
        if (vehicle.Mileage < ModelConstants.Vehicle.MinMileage || vehicle.Mileage > ModelConstants.Vehicle.MaxMileage)
            throw new BusinessLogicException($"Пробег должен быть между {ModelConstants.Vehicle.MinMileage} и {ModelConstants.Vehicle.MaxMileage}");

        // Проверка цены
        if (vehicle.Price < ModelConstants.Vehicle.MinPrice || vehicle.Price > ModelConstants.Vehicle.MaxPrice)
            throw new BusinessLogicException($"Цена должна быть между {ModelConstants.Vehicle.MinPrice} и {ModelConstants.Vehicle.MaxPrice}");

        // Проверка на уникальность VIN номера
        if (await dataContext.Vehicles.AnyAsync(
            x => x.VinNumber == vehicle.VinNumber && x.IsnVehicle != vehicle.IsnVehicle,
            cancellationToken))
        {
            throw new BusinessLogicException($"Автомобиль с VIN номером \"{vehicle.VinNumber}\" уже существует");
        }

        // Установка даты поступления для новых автомобилей
        if (vehicle.IsnVehicle == Guid.Empty)
        {
            vehicle.ArrivalDate = DateTime.UtcNow;
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Vehicle vehicle,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.CarDealershipSales.AnyAsync(x => x.IsnVehicle == vehicle.IsnVehicle, cancellationToken))
            throw new BusinessLogicException("Нельзя удалить автомобиль, который связан с продажами");
    }
}