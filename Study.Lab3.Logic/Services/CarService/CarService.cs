using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarService;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarService;

namespace Study.Lab3.Logic.Services.CarService;

public sealed class CarService : ICarService
{
    public async Task CreateOrUpdateCarValidateAndThrowAsync(
        DataContext dataContext,
        Car car,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Owners.AnyAsync(x => x.IsnOwner == car.IsnOwner, cancellationToken))
            throw new BusinessLogicException($"Владелец с идентификатором \"{car.IsnOwner}\" не существует");

        if (string.IsNullOrWhiteSpace(car.Brand))
            throw new BusinessLogicException("Марка автомобиля не может быть пустой");

        if (string.IsNullOrWhiteSpace(car.Model))
            throw new BusinessLogicException("Модель автомобиля не может быть пустой");

        if (string.IsNullOrWhiteSpace(car.LicensePlate))
            throw new BusinessLogicException("Государственный номер не может быть пустым");

        if (car.Year < ModelConstants.Car.MinYear || car.Year > ModelConstants.Car.MaxYear + 1)
            throw new BusinessLogicException($"Год выпуска должен быть между 1900 и {DateTime.Now.Year + 1}");

        if (car.Mileage < 0)
            throw new BusinessLogicException("Пробег не может быть отрицательным");

        // Проверка формата VIN
        if (!string.IsNullOrWhiteSpace(car.VinNumber) && car.VinNumber.Length != 17)
            throw new BusinessLogicException("VIN номер должен содержать 17 символов");

        // Проверка уникальности госномера
        if (await dataContext.Cars.AnyAsync(
            x => x.LicensePlate == car.LicensePlate && x.IsnCar != car.IsnCar,
            cancellationToken))
            throw new BusinessLogicException($"Автомобиль с госномером \"{car.LicensePlate}\" уже зарегистрирован");

        // Проверка уникальности VIN
        if (!string.IsNullOrWhiteSpace(car.VinNumber) && await dataContext.Cars.AnyAsync(
            x => x.VinNumber == car.VinNumber && x.IsnCar != car.IsnCar,
            cancellationToken))
            throw new BusinessLogicException($"Автомобиль с VIN \"{car.VinNumber}\" уже зарегистрирован");

        // Проверка one-to-one связи
        if (await dataContext.Cars.AnyAsync(
            x => x.IsnOwner == car.IsnOwner && x.IsnCar != car.IsnCar,
            cancellationToken))
            throw new BusinessLogicException("У владельца уже зарегистрирован автомобиль");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Car car,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Cars.AnyAsync(x => x.IsnCar == car.IsnCar, cancellationToken))
            throw new BusinessLogicException($"Машина с идентификатором \"{car.IsnCar}\" не существует");
    }
}