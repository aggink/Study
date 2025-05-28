using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Library;

namespace Study.Lab3.Logic.Interfaces.Services.Library;

public interface IAuthorService
{
    /// <summary>
    /// Проверка модели автора на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="group">Автор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateAuthorValidateAndThrowAsync(
        DataContext dataContext,
        Authors author,
        CancellationToken cancellationToken = default);
}
