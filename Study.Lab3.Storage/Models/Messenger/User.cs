using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Messenger;

/// <summary>
/// Пользователь
/// </summary>
[Index(nameof(Email), IsUnique = true)]
public class User
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Isn { get; set; }

    /// <summary>
    /// Аватар пользователя
    /// </summary>
    [ForeignKey(nameof(ProfilePicture))]
    public Guid? IsnProfilePicture { get; set; }

    /// <summary>
    /// Почтовый адрес пользователя
    /// </summary>
    [Required, MaxLength(ModelConstants.User.Email)]
    public string Email { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    [Required, MaxLength(ModelConstants.User.Username)]
    public string Username { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [MaxLength(ModelConstants.User.Phone)]
    public string Phone { get; set; }

    /// <summary>
    /// Персональный сайт пользователя
    /// </summary>
    [MaxLength(ModelConstants.User.Website)]
    public string Website { get; set; }

    /// <summary>
    /// Секция "о мне"
    /// </summary>
    public string AboutMe { get; set; }

    public virtual Image ProfilePicture { get; set; }

    [InverseProperty(nameof(Image.Uploader))]
    public virtual ICollection<Image> Images { get; set; }

    /// <summary>
    /// Сообщения пользователя
    /// </summary>
    [InverseProperty(nameof(Post.User))]
    public virtual ICollection<Post> Posts { get; set; }
}
