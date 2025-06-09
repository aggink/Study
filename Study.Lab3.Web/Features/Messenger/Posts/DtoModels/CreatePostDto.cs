using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Posts.DtoModels;

public sealed record CreatePostDto
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [Required]
    public Guid IsnUser { get; init; }

    /// <summary>
    /// Сообщение
    /// </summary>
    [Required]
    public string Message { get; init; }
}
