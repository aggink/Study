using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Library;

/// <summary>
/// Связь таблиц Жанры - Книги
/// </summary>
[Index(nameof(Genre.IsnGenre), nameof(Books.IsnBook))]
[PrimaryKey(nameof(Genre.IsnGenre), nameof(Books.IsnBook))]
public class GenreBooks
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    [ForeignKey(nameof(Genre)), Required]
    public Guid IsnGenre { get; set; }

    /// <summary>
    /// Идентификатор книги
    /// </summary>
    [ForeignKey(nameof(Book)), Required]
    public Guid IsnBook { get; set; }

    /// <summary>
    /// Автор
    /// </summary>
    public virtual Genre Genre { get; set; }

    /// <summary>
    /// Книга
    /// </summary>
    public virtual Books Book { get; set; }
}
