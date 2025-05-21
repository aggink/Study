using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Announcements.DtoModels;

public sealed record UpdateAnnouncementDto
{
    /// <summary>
    /// Идентификатор объявления
    /// </summary>
    [Required]
    public Guid IsnAnnouncement { get; init; }

    /// <summary>
    /// Заголовок объявления
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Announcement.Title)]
    public string Title { get; init; }

    /// <summary>
    /// Текст объявления
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Announcement.Content)]
    public string Content { get; init; }

    /// <summary>
    /// Важность объявления
    /// </summary>
    public bool IsImportant { get; init; }
}