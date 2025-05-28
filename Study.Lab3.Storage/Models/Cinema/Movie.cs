using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Cinema;

/// <summary>
/// Фильм
/// </summary>
public class Movie
{
    /// <summary>
    /// Идентификатор фильма
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnMovie { get; set; }

    /// <summary>
    /// Название фильма
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Movie.Title)]
    public string Title { get; set; }

    /// <summary>
    /// Описание фильма
    /// </summary>
    [MaxLength(ModelConstants.Movie.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Продолжительность в минутах
    /// </summary>
    [Required]
    [Range(ModelConstants.Movie.MinDuration, ModelConstants.Movie.MaxDuration)]
    public int Duration { get; set; }

    /// <summary>
    /// Рейтинг фильма
    /// </summary>
    [Range(ModelConstants.Movie.MinRating, ModelConstants.Movie.MaxRating)]
    public double Rating { get; set; }

    /// <summary>
    /// Год выпуска
    /// </summary>
    [Required]
    [Range(ModelConstants.Movie.MinYear, 2100)]
    public int Year { get; set; }

    /// <summary>
    /// Страна производства
    /// </summary>
    [MaxLength(ModelConstants.Movie.Country)]
    public string Country { get; set; }

    /// <summary>
    /// Возрастное ограничение
    /// </summary>
    [Range(0, ModelConstants.Movie.MaxAgeRating)]
    public int AgeRating { get; set; }

    /// <summary>
    /// Дата добавления в систему
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Активен ли фильм в прокате
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Связь с жанрами
    /// </summary>
    [InverseProperty(nameof(MovieGenre.Movie))]
    public virtual ICollection<MovieGenre> MovieGenres { get; set; }

    /// <summary>
    /// Сеансы фильма
    /// </summary>
    [InverseProperty(nameof(Session.Movie))]
    public virtual ICollection<Session> Sessions { get; set; }
}