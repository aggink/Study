using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IExamRegistrationService
{
    /// <summary>
    /// Проверяет возможность создания или обновления регистрации на экзамен
    /// </summary>
    /// <param name="dataContext">Контекст</param>
    /// <param name="registration">Регистрация на экзамен</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    Task CreateOrUpdateRegistrationValidateAndThrowAsync(
        DataContext dataContext,
        ExamRegistration registration,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверяет возможность удаления регистрации на экзамен
    /// </summary>
    /// <param name="dataContext">Контекст</param>
    /// <param name="registration">Регистрация на экзамен</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        ExamRegistration registration,
        CancellationToken cancellationToken = default);
}
