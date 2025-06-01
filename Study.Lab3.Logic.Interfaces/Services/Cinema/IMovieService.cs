using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;

namespace Study.Lab3.Logic.Interfaces.Services.Cinema;

public interface IMovieService
{
    /// <summary>
    /// Проверка модели фильма на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="movie">Фильм</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateMovieValidateAndThrowAsync(
        DataContext dataContext,
        Movie movie,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления фильма
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="movie">Фильм</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Movie movie,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности добавления жанра к фильму
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="movieGenre">Связь фильм-жанр</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task AddGenreValidateAndThrowAsync(
        DataContext dataContext,
        MovieGenre movieGenre,
        CancellationToken cancellationToken = default);
}