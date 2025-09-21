using Study.Lab3.Storage.Models.Cinema;

namespace Study.Lab3.Logic.Extensions.Cinema;

/// <summary>
/// Расширения для модели <see cref="Movie"/>
/// </summary>
public static class MovieExtensions
{
    /// <summary>
    /// Получить строку с жанрами фильма
    /// </summary>
    /// <param name="movie">Фильм</param>
    /// <returns>Строка с жанрами через запятую</returns>
    public static string GetGenresString(this Movie movie)
    {
        if (movie.MovieGenres == null || !movie.MovieGenres.Any())
            return "Жанры не указаны";

        return string.Join(", ", movie.MovieGenres
            .Where(mg => mg.Genre != null)
            .Select(mg => mg.Genre.Name)
            .OrderBy(name => name));
    }

    /// <summary>
    /// Получить строку продолжительности в формате "ч:мм"
    /// </summary>
    /// <param name="movie">Фильм</param>
    /// <returns>Форматированная строка продолжительности</returns>
    public static string GetDurationString(this Movie movie)
    {
        var hours = movie.Duration / 60;
        var minutes = movie.Duration % 60;

        if (hours > 0)
            return $"{hours}ч {minutes:00}мин";

        return $"{minutes} мин";
    }

    /// <summary>
    /// Получить строку возрастного рейтинга
    /// </summary>
    /// <param name="movie">Фильм</param>
    /// <returns>Возрастной рейтинг с плюсом</returns>
    public static string GetAgeRatingString(this Movie movie)
    {
        return movie.AgeRating == 0 ? "0+" : $"{movie.AgeRating}+";
    }

    /// <summary>
    /// Проверить, идет ли фильм в прокате
    /// </summary>
    /// <param name="movie">Фильм</param>
    /// <returns>True, если есть будущие сеансы</returns>
    public static bool IsInCinema(this Movie movie)
    {
        if (movie.Sessions == null || !movie.IsActive)
            return false;

        return movie.Sessions.Any(s => s.StartTime >= DateTime.UtcNow && s.IsActive);
    }
}