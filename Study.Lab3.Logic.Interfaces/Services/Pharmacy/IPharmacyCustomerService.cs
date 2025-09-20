using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Pharmacy;

namespace Study.Lab3.Logic.Interfaces.Services.Pharmacy;

/// <summary>
/// Интерфейс сервиса клиентов аптеки
/// </summary>
public interface IPharmacyCustomerService
{
    /// <summary>
    /// Проверка модели клиента на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="customer">Клиент</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateCustomerValidateAndThrowAsync(
        DataContext dataContext,
        PharmacyCustomer customer,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Проверка возможности удаления клиента
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="customer">Клиент</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PharmacyCustomer customer,
        CancellationToken cancellationToken = default);
}