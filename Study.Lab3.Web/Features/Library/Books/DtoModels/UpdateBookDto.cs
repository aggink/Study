using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Books.DtoModels;

public sealed record UpdateBookDto
{
    /// <summary>
    /// Идентификатор книги
    /// </summary>
    [Required]
    public Guid IsnBook { get; init; }

    /// <summary>
    /// Название книги
    /// </summary>
    [Required, MaxLength(ModelConstants.Book.Title)]
    public string Title { get; init; }

    /// <summary>
    /// Год издания
    /// </summary>
    [Required, Range(ModelConstants.Book.MinYear, ModelConstants.Book.MaxYear)]
    public int PublicationYear { get; init; }
}
