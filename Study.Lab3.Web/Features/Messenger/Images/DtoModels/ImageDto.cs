using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Models.Messenger;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Web.Features.Messenger.Images.DtoModels;

public sealed record ImageDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    /// <summary>
    /// Описание изображения
    /// </summary>
    [MaxLength(ModelConstants.Image.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required, ForeignKey(nameof(Image.Uploader))]
    public Guid UploaderId { get; init; }

    /// <summary>
    /// Массив байтов изображения
    /// </summary>
    public byte[] Data { get; init; }
}
