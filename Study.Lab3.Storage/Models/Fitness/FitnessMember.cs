using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Fitness;

namespace Study.Lab3.Storage.Models.Fitness;

/// <summary>
/// Участник фитнес-центра
/// </summary>
public class FitnessMember
{
    /// <summary>
    /// Идентификатор участника
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnMember { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessMember.SurName)]
    public string SurName { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessMember.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    [MaxLength(ModelConstants.FitnessMember.PatronymicName)]
    public string PatronymicName { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessMember.PhoneNumber)]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessMember.Email)]
    public string Email { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    [Required]
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Тип членства
    /// </summary>
    [Required]
    public MembershipType MembershipType { get; set; }

    /// <summary>
    /// Дата начала членства
    /// </summary>
    [Required]
    public DateTime MembershipStartDate { get; set; }

    /// <summary>
    /// Дата окончания членства
    /// </summary>
    [Required]
    public DateTime MembershipEndDate { get; set; }

    /// <summary>
    /// Активен ли участник
    /// </summary>
    [Required]
    public bool IsActive { get; set; }
}