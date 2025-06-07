using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Models.Messenger;

namespace Study.Lab3.Web.Features.Messenger.Posts.DtoModels;

public sealed record PostDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [ForeignKey(nameof(Post.User))]
    public Guid UserId { get; init; }

    /// <summary>
    /// Сообщение
    /// </summary>
    [Required]
    public string Message { get; init; }
}
