using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Images.DtoModels;

public sealed record CreateImageDto
{
    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required]
    public Guid IsnUploader { get; set; }

    /// <summary>
    /// Описание изображения
    /// </summary>
    [MaxLength(ModelConstants.Image.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Массив байтов изображения
    /// </summary>
    [Required]
    public byte[] Data { get; set; }
}
