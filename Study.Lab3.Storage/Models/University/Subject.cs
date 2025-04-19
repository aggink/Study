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
}
