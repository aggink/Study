using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IProfcomService
{
    /// <summary>
    /// Проверка модели профкома на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="profcom">Профком</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateProfcomValidateAndThrowAsync(
        DataContext dataContext,
        Profcom profcom,
        Guid teacherId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления мероприятия профкома
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="profcom">Профком</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Profcom profcom,
        Guid teacherId,
        CancellationToken cancellationToken = default);
}