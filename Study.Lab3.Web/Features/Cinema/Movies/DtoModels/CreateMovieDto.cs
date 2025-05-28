using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Movies.DtoModels;

public sealed record CreateMovieDto
{
    /// <summary>
    /// Название фильма
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Movie.Title)]
    public string Title { get; init; }

    /// <summary>
    /// Описание фильма
    /// </summary>
    [MaxLength(ModelConstants.Movie.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Продолжительность в минутах
    /// </summary>
    [Required]
    [Range(ModelConstants.Movie.MinDuration, ModelConstants.Movie.MaxDuration)]
    public int Duration { get; init; }

    /// <summary>
    /// Рейтинг фильма
    /// </summary>
    [Range(ModelConstants.Movie.MinRating, ModelConstants.Movie.MaxRating)]
    public double Rating { get; init; }

    /// <summary>
    /// Год выпуска
    /// </summary>
    [Required]
    [Range(ModelConstants.Movie.MinYear, 2100)]
    public int Year { get; init; }

    /// <summary>
    /// Страна производства
    /// </summary>
    [MaxLength(ModelConstants.Movie.Country)]
    public string Country { get; init; }

    /// <summary>
    /// Возрастное ограничение
    /// </summary>
    [Range(0, ModelConstants.Movie.MaxAgeRating)]
    public int AgeRating { get; init; }

    /// <summary>
    /// Идентификаторы жанров
    /// </summary>
    public Guid[] GenreIds { get; init; }
}