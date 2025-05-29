using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Library;

namespace Study.Lab3.Logic.Interfaces.Services.Library;

public interface IAuthorBookService
{
    /// <summary>
    /// Проверка связи Автор-Книга на возможность создания
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="teacherSubject">Связь Автор-Книга</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateAuthorBookValidateAndThrowAsync(
        DataContext dataContext,
        AuthorBooks authorBook,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка связи Автор-Книга на возможность удаления
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="teacherSubject">Связь Автор-Книга</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAuthorBook(
        DataContext dataContext,
        AuthorBooks authorBook,
        CancellationToken cancellationToken = default);
}
