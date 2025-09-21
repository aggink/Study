using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;

namespace Study.Lab3.Logic.Services.Cinema;

public sealed class MovieService : IMovieService
{
    public async Task CreateOrUpdateMovieValidateAndThrowAsync(
        DataContext dataContext,
        Movie movie,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(movie.Title))
            throw new BusinessLogicException("Название фильма не может быть пустым");

        if (movie.Duration <= 0)
        {
            throw new BusinessLogicException("Продолжительность фильма должна быть положительным числом");
        }

        if (movie.Year <= 0)
        {
            throw new BusinessLogicException("Год выпуска фильма должен быть положительным числом");
        }

        if (movie.Year > DateTime.Now.Year)
            throw new BusinessLogicException("Год выпуска не может быть больше текущего года");

        // Проверка на дубликат
        if (await dataContext.Movies.AnyAsync(
            x => x.Title == movie.Title &&
                 x.Year == movie.Year &&
                 x.IsnMovie != movie.IsnMovie,
            cancellationToken))
        {
            throw new BusinessLogicException(
                $"Фильм \"{movie.Title}\" ({movie.Year} год) уже существует");
        }

        // Автоматический расчет времени окончания для новых фильмов
        if (movie.IsnMovie == Guid.Empty)
        {
            movie.CreatedAt = DateTime.UtcNow;
        }

    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Movie movie,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Movies.AnyAsync(x => x.IsnMovie == movie.IsnMovie, cancellationToken))
            throw new BusinessLogicException(
                $"Фильм с идентификатором \"{movie.IsnMovie}\" не существует");

        // Проверка на наличие будущих сеансов
        var hasFutureSessions = await dataContext.Sessions
            .AnyAsync(x => x.IsnMovie == movie.IsnMovie &&
                          x.StartTime > DateTime.UtcNow,
                      cancellationToken);

        if (hasFutureSessions)
            throw new BusinessLogicException(
                "Невозможно удалить фильм, так как на него запланированы сеансы");

        // Проверка на наличие активных билетов
        var hasActiveTickets = await dataContext.Sessions
            .Where(x => x.IsnMovie == movie.IsnMovie)
            .SelectMany(x => x.Tickets)
            .AnyAsync(x => x.Status == Storage.Enums.Cinema.TicketStatus.Active,
                      cancellationToken);

        if (hasActiveTickets)
            throw new BusinessLogicException(
                "Невозможно удалить фильм, так как на него проданы активные билеты");
    }

    public async Task AddGenreValidateAndThrowAsync(
        DataContext dataContext,
        MovieGenre movieGenre,
        CancellationToken cancellationToken = default)
    {
        // Проверяем существование фильма как в базе данных, так и среди добавленных, но не сохранённых фильмов
        bool movieExists = await dataContext.Movies.AnyAsync(x => x.IsnMovie == movieGenre.IsnMovie, cancellationToken)
                           || dataContext.Movies.Local.Any(x => x.IsnMovie == movieGenre.IsnMovie);

        if (!movieExists)
            throw new BusinessLogicException(
                $"Фильм с идентификатором \"{movieGenre.IsnMovie}\" не существует");

        if (!await dataContext.Genres.AnyAsync(x => x.IsnGenre == movieGenre.IsnGenre, cancellationToken))
            throw new BusinessLogicException(
                $"Жанр с идентификатором \"{movieGenre.IsnGenre}\" не существует");

        if (await dataContext.MovieGenres.AnyAsync(
                x => x.IsnMovie == movieGenre.IsnMovie &&
                     x.IsnGenre == movieGenre.IsnGenre,
                cancellationToken))
        {
            throw new BusinessLogicException("Этот жанр уже добавлен к фильму");
        }
    }

}