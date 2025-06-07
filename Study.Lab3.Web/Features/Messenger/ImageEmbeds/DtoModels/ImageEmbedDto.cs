using Study.Lab3.Storage.Models.Messenger;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Web.Features.Messenger.ImageEmbeds.DtoModels;

public sealed record ImageEmbedDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    [Required, ForeignKey(nameof(ImageEmbed.Post))]
    public Guid PostId { get; init; }

    /// <summary>
    /// Идентификатор изображения
    /// </summary>
    [Required, ForeignKey(nameof(ImageEmbed.Image))]
    public Guid ImageId { get; init; }
}
