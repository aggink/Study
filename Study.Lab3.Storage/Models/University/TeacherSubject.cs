using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;
//Модель связи преподаватель-предмет
/// <summary>
/// Связь таблиц учителя - предметы
/// </summary>
[Index(nameof(IsnTeacher), nameof(IsnSubject))]
[PrimaryKey(nameof(IsnTeacher), nameof(IsnSubject))]
public class TeacherSubject
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    [ForeignKey(nameof(Teacher)), Required]
    public Guid IsnTeacher { get; set; }

    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [ForeignKey(nameof(Subject)), Required]
    public Guid IsnSubject { get; set; }

    /// <summary>
    /// Учитель
    /// </summary>
    public virtual Teacher Teacher { get; set; }

    /// <summary>
    /// Предмет
    /// </summary>
    public virtual Subject Subject { get; set; }
}