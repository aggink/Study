using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Лига киберспорта Станкина
/// </summary>
public class CyberSport
{
    /// <summary>
    /// Идентификатор киберспорт клуба
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnCyberSport { get; set; }

    /// <summary>
    /// Идентификатор команды
    /// </summary>
    [ForeignKey(nameof(Student))]
    public Guid IsnStudent { get; set; }

    /// <summary>
    /// Идентификатор игры
    /// </summary>
    [ForeignKey(nameof(Subject))]
    public Guid IsnSubject { get; set; }

    /// <summary>
    /// Значение очков
    /// </summary>
    [Required]
    [Range(ModelConstants.CyberSport.MinPointsValue, ModelConstants.CyberSport.MaxPointsValue)]
    public int PointsCount { get; set; }

    /// <summary>
    /// Дата выставления очков
    /// </summary>
    [Required]
    public DateTime CyberSportDate { get; set; }

    /// <summary>
    /// Студент
    /// </summary>
    public virtual Student Student { get; set; }

    /// <summary>
    /// Игра
    /// </summary>
    public virtual Subject Subject { get; set; }
}