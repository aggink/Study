/*using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Задание по предмету
/// </summary>
public class Assignment
{
    /// <summary>
    /// Идентификатор задания
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnAssignment { get; set; }

    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [ForeignKey(nameof(Subject))]
    public Guid IsnSubject { get; set; }

    /// <summary>
    /// Название задания
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Assignment.Title)]
    public string Title { get; set; }

    /// <summary>
    /// Описание задания
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Assignment.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Дата публикации
    /// </summary>
    [DataType(DataType.DateTime)]
    public DateTime PublishDate { get; set; }

    /// <summary>
    /// Крайний срок выполнения
    /// </summary>
    [DataType(DataType.DateTime)]
    public DateTime? Deadline { get; set; }

    /// <summary>
    /// Максимальная оценка
    /// </summary>
    public int MaxScore { get; set; }

    /// <summary>
    /// Предмет
    /// </summary>
    public virtual Subject Subject { get; set; }
}*/