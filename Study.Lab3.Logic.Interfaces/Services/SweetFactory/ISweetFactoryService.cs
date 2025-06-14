using Study.Lab3.Storage.Database;

namespace Study.Lab3.Logic.Interfaces.Services.SweetFactory;

public interface ISweetFactoryService
{
    /// <summary>
    /// Проверка модели фабрики на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="sweetfactory">Фабрика сладостей</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateSweetFactoryValidateAndThrowAsync(
        DataContext dataContext,
        Storage.Models.Sweets.SweetFactory sweetfactory,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления зала
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="sweetfactory">Зал</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Storage.Models.Sweets.SweetFactory sweetfactory,
        CancellationToken cancellationToken = default);
}
