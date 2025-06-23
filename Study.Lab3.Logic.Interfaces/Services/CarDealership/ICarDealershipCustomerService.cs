using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarDealership;

namespace Study.Lab3.Logic.Interfaces.Services.CarDealership;

/// <summary>
/// Интерфейс сервиса клиентов автосалона
/// </summary>
public interface ICarDealershipCustomerService
{
    /// <summary>
    /// Проверка модели клиента на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="customer">Клиент</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateCustomerValidateAndThrowAsync(
        DataContext dataContext,
        CarDealershipCustomer customer,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления клиента
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="customer">Клиент</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        CarDealershipCustomer customer,
        CancellationToken cancellationToken = default);
}