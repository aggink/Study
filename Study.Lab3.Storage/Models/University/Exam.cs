using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

public class Exam
{
    /// <summary>
    /// Уникальный идентификатор экзамена
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnExam { get; set; }

    /// <summary>
    /// Идентификатор предмета, к которому относится экзамен
    /// </summary>
    [ForeignKey(nameof(Subject))]
    public Guid IsnSubject { get; set; }

    /// <summary>
    /// Название экзамена, максимальная длина 100 символов
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Exam.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Описание экзамена, максимальная длина 500 символов
    /// </summary>
    [MaxLength(ModelConstants.Exam.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Дата проведения экзамена
    /// </summary>
    [Required]
    public DateTime ExamDate { get; set; }

    /// <summary>
    /// Продолжительность экзамена в минутах, допустимый диапазон от 30 до 240 минут
    /// </summary>
    [Required]
    [Range(ModelConstants.Exam.MinDuration, ModelConstants.Exam.MaxDuration)]
    public int Duration { get; set; }

    /// <summary>
    /// Максимально возможный балл за экзамен, от 1 до 100
    /// </summary>
    [Required]
    [Range(ModelConstants.Exam.MinScore, ModelConstants.Exam.MaxScore)]
    public int MaxScore { get; set; }

    /// <summary>
    /// Проходной балл для экзамена, от 1 до 100
    /// </summary>
    [Required]
    [Range(ModelConstants.Exam.MinScore, ModelConstants.Exam.MaxScore)]
    public int PassingScore { get; set; }
    
    /// <summary>
    /// Навигационное свойство, представляющее связь с предметом экзамена
    /// </summary>
    public virtual Subject Subject { get; set; }

    /// <summary>
    /// Коллекция регистраций студентов на данный экзамен
    /// </summary>
    [InverseProperty(nameof(ExamRegistration.Exam))]
    public virtual ICollection<ExamRegistration> Registrations { get; set; }
}