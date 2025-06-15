using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Photography;

namespace Study.Lab3.Logic.Interfaces.Services.Photography;

public interface IPhotographyClientService
{
    /// <summary>
    /// Проверка модели клиента на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="client">Клиент</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateClientValidateAndThrowAsync(
        DataContext dataContext,
        PhotographyClient client,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления клиента
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="client">Клиент</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PhotographyClient client,
        CancellationToken cancellationToken = default);
}