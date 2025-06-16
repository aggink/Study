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
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnImage { get; set; }

    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required, ForeignKey(nameof(Uploader))]
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

    /// <summary>
    /// Автор
    /// </summary>
    public virtual User Uploader { get; set; }

    /// <summary>
    /// Профиль пользователя
    /// </summary>
    [InverseProperty(nameof(User.ProfilePicture))]
    public virtual User Profile { get; set; }

    /// <summary>
    /// Вложения
    /// </summary>
    [InverseProperty(nameof(ImageEmbed.Image))]
    public virtual ICollection<ImageEmbed> ImageEmbeds { get; set; }
}
