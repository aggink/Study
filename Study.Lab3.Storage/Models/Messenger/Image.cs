using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Messenger;

/// <summary>
/// Изображение
/// </summary>
public class Image
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Isn { get; set; }

    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required, ForeignKey(nameof(Uploader))]
    public Guid IsnUploader { get; set; }

    public virtual User Uploader { get; set; }

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

    /// <summary>
    /// Вложения
    /// </summary>
    [InverseProperty(nameof(ImageEmbed.Image))]
    public virtual ICollection<ImageEmbed> ImageEmbeds { get; set; }
}
