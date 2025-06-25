using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarDealership;

namespace Study.Lab3.Logic.Interfaces.Services.CarDealership;

/// <summary>
/// Интерфейс сервиса автомобилей
/// </summary>
public interface IVehicleService
{
    /// <summary>
    /// Проверка модели автомобиля на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="vehicle">Автомобиль</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateVehicleValidateAndThrowAsync(
        DataContext dataContext,
        Vehicle vehicle,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления автомобиля
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="vehicle">Автомобиль</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Vehicle vehicle,
        CancellationToken cancellationToken = default);
}