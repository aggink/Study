using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Fitness;

namespace Study.Lab3.Web.Features.Fitness.Member.DtoModels;

public sealed record CreateMemberDto
{
    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessMember.SurName)]
    public string SurName { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessMember.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Отчество
    /// </summary>
    [MaxLength(ModelConstants.FitnessMember.PatronymicName)]
    public string PatronymicName { get; init; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessMember.PhoneNumber)]
    public string PhoneNumber { get; init; }

    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.FitnessMember.Email)]
    public string Email { get; init; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    [Required]
    public DateTime DateOfBirth { get; init; }

    /// <summary>
    /// Тип членства
    /// </summary>
    [Required]
    public MembershipType MembershipType { get; init; }

    /// <summary>
    /// Дата начала членства
    /// </summary>
    [Required]
    public DateTime MembershipStartDate { get; init; }

    /// <summary>
    /// Дата окончания членства
    /// </summary>
    [Required]
    public DateTime MembershipEndDate { get; init; }

    /// <summary>
    /// Активен ли участник
    /// </summary>
    public bool IsActive { get; init; } = true;
}
