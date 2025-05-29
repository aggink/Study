using Study.Lab3.Storage.Enums.University;

namespace Study.Lab3.Web.Features.Library.AuthorBooks.DtoModels;

public sealed record AuthorBookWithDetailsDto
{
    /// <summary>
    /// Идентификатор автора
    /// </summary>
    public Guid IsnAuthor { get; init; }

    /// <summary>
    /// ФИО автора
    /// </summary>
    public string AuthorFullName { get; init; }

    /// <summary>
    /// Пол
    /// </summary>
    public SexType Sex { get; init; }

    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid? IsnTeacher { get; init; }

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
