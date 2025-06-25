using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Посещаемость
/// </summary>
public class AttendanceLog
{
    /// <summary>
    /// Идентификатор посещаемости
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnAttendanceLog { get; set; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [ForeignKey(nameof(Student))]
    public Guid IsnStudent { get; set; }

    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [ForeignKey(nameof(Subject))]
    public Guid IsnSubject { get; set; }

    /// <summary>
    /// Дата занятия
    /// </summary>
    [Required]
    public DateTime SubjectDate { get; set; }

    /// <summary>
    /// Отметка посещения
    /// </summary>
    [Required]
    [Range(ModelConstants.AttendanceLog.MinPresentValue, ModelConstants.AttendanceLog.MaxPresentValue)]
    public int IsPresent { get; set; }

    /// <summary>
    /// Студент
    /// </summary>
    public virtual Student Student { get; set; }

    /// <summary>
    /// Предмет
    /// </summary>
    public virtual Subject Subject { get; set; }
}
