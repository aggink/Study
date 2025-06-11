using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Модель заметки студента
/// </summary>
public class StudentNote
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnNote { get; set; }

    [ForeignKey(nameof(Student))]
    public Guid IsnStudent { get; set; }

    [Required]
    [MaxLength(500)]
    public string Text { get; set; }

    /// <summary>
    /// Студент
    /// </summary>
    public virtual Student Student { get; set; }
}