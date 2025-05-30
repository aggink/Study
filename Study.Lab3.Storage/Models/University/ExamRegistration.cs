using Study.Lab3.Storage.Enums.University;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

public class ExamRegistration
{
    /// <summary>
    /// Уникальный идентификатор регистрации на экзамен
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnExamRegistration { get; set; }

    /// <summary>
    /// Идентификатор экзамена, на который зарегистрирован студент
    /// </summary>
    [ForeignKey(nameof(Exam))]
    public Guid IsnExam { get; set; }

    /// <summary>
    /// Идентификатор студента, зарегистрированного на экзамен
    /// </summary>
    [ForeignKey(nameof(Student))]
    public Guid IsnStudent { get; set; }

    /// <summary>
    /// Дата регистрации на экзамен
    /// </summary>
    [Required]
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// Текущий статус регистрации
    /// </summary>
    [Required]
    public RegistrationStatus Status { get; set; }
    
    /// <summary>
    /// Навигационное свойство, указывающее на связанный экзамен
    /// </summary>
    public virtual Exam Exam { get; set; }
    
    /// <summary>
    /// Навигационное свойство, указывающее на связанного студента
    /// </summary>
    public virtual Student Student { get; set; }
    
    /// <summary>
    /// Навигационное свойство, указывающее на результат экзамена
    /// </summary>
    [InverseProperty(nameof(ExamResult.Registration))]
    public virtual ExamResult Result { get; set; }
}