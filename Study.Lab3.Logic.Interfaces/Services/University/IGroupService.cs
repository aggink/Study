using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IGroupService
{
    /// <summary>
    /// Проверка модели группы на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="group">Группа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateGroupValidateAndThrowAsync(
        DataContext dataContext,
        Group group,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления группы
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="group">Группа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Group group,
        CancellationToken cancellationToken = default);
}
