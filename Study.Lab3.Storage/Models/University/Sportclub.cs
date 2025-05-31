using Study.Lab3.Storage.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Storage.Models.University;

public class Sportclub
{
    /// <summary>
    /// Идентификатор спортивного клуба
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnSportclub { get; set; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [ForeignKey(nameof(Student))]
    public Guid IsnStudent { get; set; }

    /// <summary>
    /// Идентификатор соревнований
    /// </summary>
    [ForeignKey(nameof(Subject))]
    public Guid IsnSubject { get; set; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    [Required]
    [Range(ModelConstants.Sportclub.MinParticipantValue, ModelConstants.Sportclub.MaxParticipantValue)]
    public int ParticipantsCount { get; set; }

    /// <summary>
    /// Дата соревнований
    /// </summary>
    [Required]
    public DateTime SportclubDate { get; set; }

    /// <summary>
    /// Студент
    /// </summary>
    public virtual Student Student { get; set; }

    /// <summary>
    /// Соревнования
    /// </summary>
    public virtual Subject Subject { get; set; }
}
