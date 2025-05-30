namespace Study.Lab3.Web.Features.Library.Books.DtoModels;

public sealed record BookDto
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
}
