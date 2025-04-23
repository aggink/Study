using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface ISubjectService
{
    /// <summary>
    /// Проверка модели предмета на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext"></param>
    /// <param name="subject"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateOrUpdateSubjectAndThrowAsync(
        DataContext dataContext,
        Subject subject,
        CancellationToken cancellationToken = default);
}
