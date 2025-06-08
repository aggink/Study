using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Проектная деятельность
/// </summary>
public class ProjectActivities
{
    /// <summary>
    /// Идентификатор проектной деятельности
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnProjectActivities { get; set; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [ForeignKey(nameof(Student))]
    public Guid IsnStudent { get; set; }

    /// <summary>
    /// Идентификатор темы выступления
    /// </summary>
    [ForeignKey(nameof(Subject))]
    public Guid IsnSubject { get; set; }

    /// <summary>
    /// Значение количества выступлений
    /// </summary>
    [Required]
    [Range(ModelConstants.ProjectActivities.MinPerformancesValue, ModelConstants.ProjectActivities.MaxPerformancesValue)]
    public int ParticipantsCount { get; set; }

    /// <summary>
    /// Дата выступлений
    /// </summary>
    [Required]
    public DateTime ProjectActivitiesDate { get; set; }

    /// <summary>
    /// Студент
    /// </summary>
    public virtual Student Student { get; set; }

    /// <summary>
    /// Тема выступления
    /// </summary>
    public virtual Subject Subject { get; set; }
}