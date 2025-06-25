namespace Study.Lab3.Web.Features.AsianComics.Manhva.DtoModels;

public sealed record ManhvaDto
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
