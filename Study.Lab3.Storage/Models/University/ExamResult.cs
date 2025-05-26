/*using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

public class ExamResult
{
    /// <summary>
    /// Уникальный идентификатор результата экзамена.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnExamResult { get; set; }

    /// <summary>
    /// Внешний ключ для связи с регистрацией на экзамен.
    /// </summary>
    [ForeignKey(nameof(Registration))]
    public Guid IsnExamRegistration { get; set; }

    /// <summary>
    /// Балл, полученный за экзамен (от 0 до 100).
    /// </summary>
    [Required]
    [Range(ModelConstants.ExamResult.MinScore, ModelConstants.ExamResult.MaxScore)]
    public int Score { get; set; }

    /// <summary>
    /// Флаг, указывающий, сдан ли экзамен.
    /// </summary>
    [Required]
    public bool IsPassed { get; set; }

    /// <summary>
    /// Комментарии к результату экзамена.
    /// </summary>
    [MaxLength(ModelConstants.ExamResult.Comments)]
    public string Comments { get; set; }
    
    /// <summary>
    /// Навигационное свойство для связи с регистрацией на экзамен.
    /// </summary>
    public virtual ExamRegistration Registration { get; set; }
}*/