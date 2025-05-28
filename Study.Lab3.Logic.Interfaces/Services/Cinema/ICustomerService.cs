using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;

namespace Study.Lab3.Logic.Interfaces.Services.Cinema;

public interface ICustomerService
{
    /// <summary>
    /// Проверка модели клиента на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="customer">Клиент</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateCustomerValidateAndThrowAsync(
        DataContext dataContext,
        Customer customer,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления клиента
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="customer">Клиент</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Customer customer,
        CancellationToken cancellationToken = default);
}