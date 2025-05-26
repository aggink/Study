/*using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IExamResultService
{
    /// <summary>
    /// Проверяет, что результат экзамена можно создать или обновить
    /// </summary>
    /// <param name="dataContext">Контекст</param>
    /// <param name="result">Результат экзамена</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateResultValidateAndThrowAsync(
        DataContext dataContext,
        ExamResult result,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверяет, что результат экзамена можно удалить
    /// </summary>
    /// <param name="dataContext">Контекст</param>
    /// <param name="result">Результат экзамена</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        ExamResult result,
        CancellationToken cancellationToken = default);
}*/