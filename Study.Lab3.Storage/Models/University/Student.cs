using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.University;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;
//Модель студента
/// <summary>
/// Студент
/// </summary>
[Index(nameof(IsnGroup))]
public class Student
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnStudent { get; set; }

    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [ForeignKey(nameof(Group))]
    public Guid IsnGroup { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required, MaxLength(ModelConstants.Student.SurName)]
    public string SurName { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required, MaxLength(ModelConstants.Student.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    [Required, MaxLength(ModelConstants.Student.PatronymicName)]
    public string PatronymicName { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public SexType Sex { get; set; }

    /// <summary>
    /// Возраст
    /// </summary>
    [Range(ModelConstants.Student.AgeMin, ModelConstants.Student.AgeMax)]
    public int Age { get; set; }

    /// <summary>
    /// Группа
    /// </summary>
    public virtual Group Group { get; set; }

    /// <summary>
    /// Связь с таблицей студента - оценки
    /// </summary>
    [InverseProperty(nameof(Grade.Student))]
    public virtual ICollection<Grade> Grades { get; set; } = new HashSet<Grade>();
}
