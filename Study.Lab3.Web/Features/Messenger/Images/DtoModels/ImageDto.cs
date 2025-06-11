using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Images.DtoModels;

public sealed record ImageDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required]
    public Guid Isn { get; init; }

    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required]
    public Guid IsnUploader { get; init; }

    /// <summary>
    /// Описание изображения
    /// </summary>
    [MaxLength(ModelConstants.Image.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Массив байтов изображения
    /// </summary>
    public byte[] Data { get; init; }
}
