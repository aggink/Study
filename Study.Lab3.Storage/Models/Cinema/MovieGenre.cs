using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Cinema;

/// <summary>
/// Связь фильма с жанром (многие-ко-многим)
/// </summary>
[PrimaryKey(nameof(IsnMovie), nameof(IsnGenre))]
public class MovieGenre
{
    /// <summary>
    /// Идентификатор фильма
    /// </summary>
    [ForeignKey(nameof(Movie))]
    public Guid IsnMovie { get; set; }

    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    [ForeignKey(nameof(Genre))]
    [Required]
    public Guid IsnGenre { get; set; }

    /// <summary>
    /// Фильм
    /// </summary>
    public virtual Movie Movie { get; set; }

    /// <summary>
    /// Жанр
    /// </summary>
    public virtual Genre Genre { get; set; }
}