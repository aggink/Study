using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.ImageEmbeds.DtoModels;

public sealed record UpdateImageEmbedDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required]
    public Guid Isn { get; set; }

    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    [Required]
    public Guid? IsnPost { get; init; }

    /// <summary>
    /// Идентификатор изображения
    /// </summary>
    [Required]
    public Guid? IsnImage { get; init; }
}
