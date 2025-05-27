using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;

namespace Study.Lab3.Logic.Interfaces.Services.Cinema;

public interface IGenreService
{
    /// <summary>
    /// Проверка модели жанра на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="genre">Жанр</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateGenreValidateAndThrowAsync(
        DataContext dataContext,
        Genre genre,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления жанра
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="genre">Жанр</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Genre genre,
        CancellationToken cancellationToken = default);
}