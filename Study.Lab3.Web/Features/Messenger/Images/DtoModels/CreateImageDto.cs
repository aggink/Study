using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Models.Messenger;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Web.Features.Messenger.Images.DtoModels;

public sealed record CreateImageDto
{
    /// <summary>
    /// Описание изображения
    /// </summary>
    [MaxLength(ModelConstants.Image.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required, ForeignKey(nameof(User))]
    public Guid UploaderId { get; set; }

    /// <summary>
    /// Массив байтов изображения
    /// </summary>
    [Required]
    public byte[] Data { get; set; }
}
