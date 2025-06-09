using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Оценки студента по лабе
/// </summary>
[Index(nameof(IsnStudent))]
[Index(nameof(IsnLab))]
public class StudentLab
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnStudentLab { get; set; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [ForeignKey(nameof(Student))]
    public Guid IsnStudent { get; set; }

    /// <summary>
    /// Идентификатор лабы
    /// </summary>
    [ForeignKey(nameof(Labs))]
    public Guid IsnLab { get; set; }

    /// <summary>
    /// Оценка
    /// </summary>
    [Range(0, 54)]
    public int Value { get; set; }

    /// <summary>
    /// Студент
    /// </summary>
    public virtual Student Student { get; set; }

    /// <summary>
    /// Лаба
    /// </summary>
    public virtual Labs Labs { get; set; }
}