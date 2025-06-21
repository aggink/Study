namespace Study.Lab3.Web.Features.AsianComics.Manga.DtoModels;

public sealed record MangaDto
{
    /// <summary>
    /// Идентификатор манги
    /// </summary>
    public Guid IsnBook { get; init; }

    /// <summary>
    /// Название манги
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    /// Год издания
    /// </summary>
    public int PublicationYear { get; init; }
}
