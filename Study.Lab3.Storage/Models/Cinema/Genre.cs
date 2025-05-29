using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Cinema;

/// <summary>
/// Жанр фильма
/// </summary>
public class Genre
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnGenre { get; set; }

    /// <summary>
    /// Название жанра
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Genre.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Связь с фильмами
    /// </summary>
    [InverseProperty(nameof(MovieGenre.Genre))]
    public virtual ICollection<MovieGenre> MovieGenres { get; set; }
}