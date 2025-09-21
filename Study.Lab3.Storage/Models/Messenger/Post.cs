using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Messenger;

/// <summary>
/// Сообщение
/// </summary>
public class Post
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPost { get; set; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [Required, ForeignKey(nameof(User))]
    public Guid IsnUser { get; set; }

    /// <summary>
    /// Сообщение
    /// </summary>
    [Required]
    public string Message { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public virtual User User { get; set; }

    /// <summary>
    /// Вложенные изображения
    /// </summary>
    [InverseProperty(nameof(ImageEmbed.Post))]
    public virtual ICollection<ImageEmbed> ImageEmbeds { get; set; }
}
