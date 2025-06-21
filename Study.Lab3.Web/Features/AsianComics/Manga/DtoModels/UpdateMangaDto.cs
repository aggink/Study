using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manga.DtoModels;

public sealed record UpdateMangaDto
{
    /// <summary>
    /// Идентификатор манги
    /// </summary>
    [Required]
    public Guid IsnBook { get; init; }

    /// <summary>
    /// Название манги
    /// </summary>
    [Required, MaxLength(ModelConstants.AsianComicsConstants.Title)]
    public string Title { get; init; }

    /// <summary>
    /// Год издания
    /// </summary>
    [Required, Range(ModelConstants.AsianComicsConstants.MinYear, ModelConstants.AsianComicsConstants.MaxYear)]
    public int PublicationYear { get; init; }
}
