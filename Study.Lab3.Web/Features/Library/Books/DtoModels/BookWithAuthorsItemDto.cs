using Study.Lab3.Web.Features.Library.Authors.DtoModels;

namespace Study.Lab3.Web.Features.Library.Books.DtoModels;

public class BookWithAuthorsItemDto
{
    /// <summary>
    /// Идентификатор книги
    /// </summary>
    public Guid IsnBook { get; init; }

    /// <summary>
    /// Название книги
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    /// Год издания
    /// </summary>
    public int PublicationYear { get; init; }

    /// <summary>
    /// Жанр книги
    /// </summary>
    public string Genre { get; init; }

    /// <summary>
    /// Список авторов
    /// </summary>
    public AuthorItemDto[] Authors { get; init; }
}
