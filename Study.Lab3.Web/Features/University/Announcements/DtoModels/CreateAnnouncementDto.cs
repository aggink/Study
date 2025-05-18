using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Announcements.DtoModels;

public sealed record CreateAnnouncementDto
{
    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    [Required]
    public Guid IsnTeacher { get; init; }

    /// <summary>
    /// Заголовок объявления
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string Title { get; init; }

    /// <summary>
    /// Текст объявления
    /// </summary>
    [Required]
    public string Content { get; init; }

    /// <summary>
    /// Дата публикации
    /// </summary>
    public DateTime PublishDate { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Важность объявления
    /// </summary>
    public bool IsImportant { get; init; }

    /// <summary>
    /// Идентификаторы групп
    /// </summary>
    public Guid[] GroupIds { get; init; }
}