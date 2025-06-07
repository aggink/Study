using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Messenger;

/// <summary>
/// Внедрение изображения в сообщение
/// </summary>
public class ImageEmbed
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    [Required, ForeignKey(nameof(Post))]
    public Guid PostId { get; set; }

    /// <summary>
    /// Идентификатор изображения
    /// </summary>
    [Required, ForeignKey(nameof(Image))]
    public Guid ImageId { get; set; }

    public virtual Post Post { get; set; }

    public virtual Image Image { get; set; }
}
