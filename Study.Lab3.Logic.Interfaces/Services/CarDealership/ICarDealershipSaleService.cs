using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarDealership;

namespace Study.Lab3.Logic.Interfaces.Services.CarDealership;

/// <summary>
/// Интерфейс сервиса продаж автомобилей
/// </summary>
public interface ICarDealershipSaleService
{
    /// <summary>
    /// Проверка модели продажи на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="sale">Продажа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateSaleValidateAndThrowAsync(
        DataContext dataContext,
        CarDealershipSale sale,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления продажи
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="sale">Продажа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        CarDealershipSale sale,
        CancellationToken cancellationToken = default);
}