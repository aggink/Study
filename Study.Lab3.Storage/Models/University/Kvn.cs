using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Оценки
/// </summary>
public class Kvn
{
    /// <summary>
    /// Идентификатор квн
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnKvn { get; set; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [ForeignKey(nameof(Student))]
    public Guid IsnStudent { get; set; }

    /// <summary>
    /// Идентификатор выступления
    /// </summary>
    [ForeignKey(nameof(Subject))]
    public Guid IsnSubject { get; set; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    [Required]
    [Range(ModelConstants.Kvn.MinPart, ModelConstants.Kvn.MaxPart)]
    public int ParticipantsCount { get; set; }

    /// <summary>
    /// Дата мероприятия
    /// </summary>
    [Required]
    public DateTime KvnDate { get; set; }

    /// <summary>
    /// Участник
    /// </summary>
    public virtual Student Student { get; set; }

    /// <summary>
    /// Тема выступления
    /// </summary>
    public virtual Subject Subject { get; set; }
}