using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.MusicStore;

namespace Study.Lab3.Logic.Interfaces.Services.MusicStore;

public interface IMusicCustomerService
{
    /// <summary>
    /// Проверка модели покупателя на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="customer">Покупатель</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateCustomerValidateAndThrowAsync(
        DataContext dataContext,
        MusicCustomer customer,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления покупателя
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="customer">Покупатель</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        MusicCustomer customer,
        CancellationToken cancellationToken = default);
}
