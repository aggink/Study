using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Books.DtoModels;

public sealed record UpdateBookDto
{
    /// <summary>
    /// Идентификатор книги
    /// </summary>
    [Required]
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
    /// Жанр книги
    /// </summary>
    [Required, MaxLength(ModelConstants.Book.Genre)]
    public string Genre { get; set; }
}
