using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Models.Messenger;

namespace Study.Lab3.Web.Features.Messenger.ImageEmbeds.DtoModels;

public sealed record CreateImageEmbedDto
{
    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    [ForeignKey(nameof(ImageEmbed.Post))]
    public Guid PostId { get; init; }

    /// <summary>
    /// Идентификатор изображения
    /// </summary>
    [ForeignKey(nameof(ImageEmbed.Image))]
    public Guid ImageId { get; init; }
}
