using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.AsianComics.Manhua.DtoModels;

public sealed record CreateManhuaDto
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
