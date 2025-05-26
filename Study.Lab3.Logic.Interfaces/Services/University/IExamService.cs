/*using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IExamService
{
    /// <summary>
    /// Проверка модели экзамена на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст</param>
    /// <param name="exam">Экзамен</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateExamValidateAndThrowAsync(
        DataContext dataContext,
        Exam exam,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления экзамена и генерация исключения при невозможности удаления
    /// </summary>
    /// <param name="dataContext">Контекст</param>
    /// <param name="exam">Экзамен</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Exam exam,
        CancellationToken cancellationToken = default);
}*/