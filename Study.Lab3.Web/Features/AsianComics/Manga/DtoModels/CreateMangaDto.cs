using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manga.DtoModels;

public sealed record CreateMangaDto
{
    /// <summary>
    /// �������� �����
    /// </summary>
    [Required, MaxLength(ModelConstants.AsianComicsConstants.Title)]
    public string Title { get; init; }

    /// <summary>
    /// ��� �������
    /// </summary>
    [Required, Range(ModelConstants.AsianComicsConstants.MinYear, ModelConstants.AsianComicsConstants.MaxYear)]
    public int PublicationYear { get; init; }
}
