using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Posts.DtoModels;

public sealed record UpdatePostDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required]
    public Guid Isn { get; init; }

    /// <summary>
    /// Сообщение
    /// </summary>
    [Required]
    public string Message { get; init; }
}
