using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.University;
using Study.Lab3.Storage.Models.Library;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Учитель
/// </summary>
public class Teacher
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnTeacher { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required, MaxLength(ModelConstants.Teacher.SurName)]
    public string SurName { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required, MaxLength(ModelConstants.Teacher.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    [Required, MaxLength(ModelConstants.Teacher.PatronymicName)]
    public string PatronymicName { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public SexType Sex { get; set; }

    /// <summary>
    /// Объявление от преподавателя
    /// </summary>
    [InverseProperty(nameof(Announcement.Teacher))]
    public virtual ICollection<Announcement> Announcements { get; set; }

    /// <summary>
    /// Связь с таблицей учителя - предметы
    /// </summary>
    [InverseProperty(nameof(TeacherSubject.Teacher))]
    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }

    /// <summary>
    /// Связь с таблицей авторов
    /// </summary>
    [InverseProperty(nameof(Authors.Teacher))]
    public virtual Authors Author { get; set; }
}