using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Library;

/// <summary>
/// Связь таблиц Авторы - Книги
/// </summary>
[Index(nameof(IsnAuthor), nameof(IsnBook))]
[PrimaryKey(nameof(IsnAuthor), nameof(IsnBook))]
public class AuthorBooks
{
    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [ForeignKey(nameof(Author)), Required]
    public Guid IsnAuthor { get; set; }

    /// <summary>
    /// Идентификатор книги
    /// </summary>
    [ForeignKey(nameof(Book)), Required]
    public Guid IsnBook { get; set; }

    /// <summary>
    /// Автор
    /// </summary>
    public virtual Authors Author { get; set; }

    /// <summary>
    /// Книга
    /// </summary>
    public virtual Books Book { get; set; }
}
