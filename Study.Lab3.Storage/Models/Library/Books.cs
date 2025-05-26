using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Library;

/// <summary>
/// Книга
/// </summary>
public class Books
{
    /// <summary>
    /// Идентификатор книги
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnBook { get; set; }

    /// <summary>
    /// Название книги
    /// </summary>
    [Required, MaxLength(ModelConstants.Book.Title)]
    public string Title { get; set; }

    /// <summary>
    /// Год издания
    /// </summary>
    [Required, Range(ModelConstants.Book.MinYear, ModelConstants.Book.MaxYear)]
    public int PublicationYear { get; set; }

    /// <summary>
    /// Связь с таблицей Авторы - Книги
    /// </summary>
    [InverseProperty(nameof(AuthorBooks.Book))]
    public virtual ICollection<AuthorBooks> AuthorBook { get; set; }
}
