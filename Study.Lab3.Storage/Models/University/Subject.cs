using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Предмет
/// </summary>
public class Subject
{
    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnSubject { get; set; }

    /// <summary>
    /// Название предмета
    /// </summary>
    [Required, MaxLength(ModelConstants.Subject.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Связь с таблицей группы - предметы
    /// </summary>
    [InverseProperty(nameof(SubjectGroup.Subject))]
    public virtual ICollection<SubjectGroup> GroupSubjects { get; set; }

    /// <summary>
    /// Оценки по предмету
    /// </summary>
    [InverseProperty(nameof(Grade.Subject))]
    public virtual ICollection<Grade> Grades { get; set; }

    /// <summary>
    /// Связь с учителями
    /// </summary>
    [InverseProperty(nameof(TeacherSubject.Subject))]
    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }

    /// <summary>
    /// Связь с предметами
    /// </summary>
    [InverseProperty(nameof(Assignment.Subject))]
    public virtual ICollection<Assignment> Assignments { get; set; }

    /// <summary>
    /// Учебные материалы
    /// </summary>
    [InverseProperty(nameof(Material.Subject))]
    public virtual ICollection<Material> Materials { get; set; }

    /// <summary>
    /// Связь с экзаменами
    /// </summary>
    [InverseProperty(nameof(Exam.Subject))]
    public virtual ICollection<Exam> Exams { get; set; }

    /// <summary>
    /// Соревнования по виду спорта
    /// </summary>
    [InverseProperty(nameof(Sportclub.Subject))]
    public virtual ICollection<Sportclub> Sportclubs { get; set; }

    /// <summary>
    /// Связь с квн
    /// </summary>
    [InverseProperty(nameof(Kvn.Subject))]
    public virtual ICollection<Kvn> Kvns { get; set; }
}
