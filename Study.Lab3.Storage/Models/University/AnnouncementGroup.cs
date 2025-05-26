/*using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Связь объявления с группами
/// </summary>
[Index(nameof(IsnAnnouncement), nameof(IsnGroup))]
[PrimaryKey(nameof(IsnAnnouncement), nameof(IsnGroup))]
public class AnnouncementGroup
{
    /// <summary>
    /// Идентификатор объявления
    /// </summary>
    [ForeignKey(nameof(Announcement))]
    [Required]
    public Guid IsnAnnouncement { get; set; }

    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [ForeignKey(nameof(Group))]
    [Required]
    public Guid IsnGroup { get; set; }

    /// <summary>
    /// Объявление
    /// </summary>
    public virtual Announcement Announcement { get; set; }

    /// <summary>
    /// Группа
    /// </summary>
    public virtual Group Group { get; set; }
}*/