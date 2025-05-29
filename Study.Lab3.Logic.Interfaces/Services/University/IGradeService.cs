using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IGradeService
{
    /// <summary>
    /// Проверка модели оценки на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="grade">Оценка</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateGradeValidateAndThrowAsync(
        DataContext dataContext,
        Grade grade,
        Guid teacherId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления оценки
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="grade">Оценка</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Grade grade,
        Guid teacherId,
        CancellationToken cancellationToken = default);
}