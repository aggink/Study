using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Messenger;

/// <summary>
/// Вложение изображения в сообщение
/// </summary>
public class ImageEmbed
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnImageEmbed { get; set; }

    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    [Required, ForeignKey(nameof(Post))]
    public Guid IsnPost { get; set; }

    /// <summary>
    /// Идентификатор изображения
    /// </summary>
    [Required, ForeignKey(nameof(Image))]
    public Guid IsnImage { get; set; }

    /// <summary>
    /// Сообщение
    /// </summary>
    public virtual Post Post { get; set; }

    /// <summary>
    /// Изображение
    /// </summary>
    public virtual Image Image { get; set; }
}
