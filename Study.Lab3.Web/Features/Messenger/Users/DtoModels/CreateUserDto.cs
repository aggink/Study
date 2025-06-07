using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Models.Messenger;

namespace Study.Lab3.Web.Features.Messenger.Users.DtoModels;

public sealed record CreateUserDto
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    /// <summary>
    /// Почтовый адрес пользователя
    /// </summary>
    [Required, MaxLength(ModelConstants.User.Email)]
    public string Email { get; init; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    [Required, MaxLength(ModelConstants.User.Username)]
    public string Username { get; init; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [MaxLength(ModelConstants.User.Phone)]
    public string Phone { get; init; }

    /// <summary>
    /// Персональный сайт пользователя
    /// </summary>
    [MaxLength(ModelConstants.User.Website)]
    public string Website { get; init; }

    /// <summary>
    /// Секция "о мне"
    /// </summary>
    public string AboutMe { get; init; }

    /// <summary>
    /// Аватар пользователя
    /// </summary>
    [ForeignKey(nameof(User.ProfilePicture))]
    public Guid? ProfilePicture { get; init; }
}
