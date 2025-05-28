using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Library;

namespace Study.Lab3.Logic.Interfaces.Services.Library;

public interface IBookService
{
    /// <summary>
    /// Проверка модели книги на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="group">Книга</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateBookValidateAndThrowAsync(
        DataContext dataContext,
        Books book,
        CancellationToken cancellationToken = default);
}
