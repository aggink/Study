using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;

namespace Study.Lab3.Logic.Services.Cinema;

public sealed class GenreService : IGenreService
{
    public async Task CreateOrUpdateGenreValidateAndThrowAsync(
        DataContext dataContext,
        Genre genre,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(genre.Name))
            throw new BusinessLogicException("Название жанра не может быть пустым");

        // Проверка на дубликат
        if (await dataContext.Genres.AnyAsync(
                x => x.Name == genre.Name && x.IsnGenre != genre.IsnGenre,
                cancellationToken))
        {
            throw new BusinessLogicException($"Жанр \"{genre.Name}\" уже существует");
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Genre genre,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Genres.AnyAsync(x => x.IsnGenre == genre.IsnGenre, cancellationToken))
            throw new BusinessLogicException(
                $"Жанр с идентификатором \"{genre.IsnGenre}\" не существует");

        // Проверка на связи с фильмами
        if (await dataContext.MovieGenres.AnyAsync(x => x.IsnGenre == genre.IsnGenre, cancellationToken))
            throw new BusinessLogicException(
                "Невозможно удалить жанр, так как он используется в фильмах");
    }
}