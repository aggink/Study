using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;
//Модель оценки студента по предмету
/// <summary>
/// Оценки
/// </summary>
public class Grade
{
    /// <summary>
    /// Идентификатор оценки
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnGrade { get; set; }

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
    /// Значение оценки
    /// </summary>
    [Required]
    [Range(ModelConstants.Grade.MinValue, ModelConstants.Grade.MaxValue)]
    public int Value { get; set; }

    /// <summary>
    /// Дата выставления оценки
    /// </summary>
    [Required]
    public DateTime GradeDate { get; set; }

    /// <summary>
    /// Студент
    /// </summary>
    [InverseProperty(nameof(Student.Grades))]
    public virtual Student Student { get; set; }

    /// <summary>
    /// Предмет
    /// </summary>
    [InverseProperty(nameof(Subject.Grades))]
    public virtual Subject Subject { get; set; }
}