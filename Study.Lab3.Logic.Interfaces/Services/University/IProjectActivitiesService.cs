using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IProjectActivitiesService
{
    /// <summary>
    /// Проверка модели проектной деятельности на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="projectactivities">Профком</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateProjectActivitiesValidateAndThrowAsync(
        DataContext dataContext,
        ProjectActivities projectactivities,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления проектной деятельности
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="projectactivities">Профком</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        ProjectActivities projectactivities,
        CancellationToken cancellationToken = default);
}