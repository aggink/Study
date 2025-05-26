/*using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Объявление от преподавателя
/// </summary>
public class Announcement
{
    /// <summary>
    /// Идентификатор объявления
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnAnnouncement { get; set; }

    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    [ForeignKey(nameof(Teacher))]
    public Guid IsnTeacher { get; set; }

    /// <summary>
    /// Заголовок объявления
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Announcement.Title)]
    public string Title { get; set; }

    /// <summary>
    /// Текст объявления
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Announcement.Content)]
    public string Content { get; set; }

    /// <summary>
    /// Дата публикации
    /// </summary>
    public DateTime PublishDate { get; set; }

    /// <summary>
    /// Важность объявления
    /// </summary>
    public bool IsImportant { get; set; }

    /// <summary>
    /// Преподаватель
    /// </summary>
    public virtual Teacher Teacher { get; set; }

    /// <summary>
    /// Связь с группами
    /// </summary>
    [InverseProperty(nameof(AnnouncementGroup.Announcement))]
    public virtual ICollection<AnnouncementGroup> AnnouncementGroups { get; set; }
}*/