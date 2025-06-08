using Study.Lab3.Storage.Enums.Fitness;

namespace Study.Lab3.Web.Features.Fitness.Member.DtoModels;

public sealed record MemberDto
{
    /// <summary>
    /// Идентификатор участника
    /// </summary>
    public Guid IsnMember { get; init; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string SurName { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string PatronymicName { get; init; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; init; }

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime DateOfBirth { get; init; }

    /// <summary>
    /// Тип членства
    /// </summary>
    public MembershipType MembershipType { get; init; }

    /// <summary>
    /// Дата начала членства
    /// </summary>
    public DateTime MembershipStartDate { get; init; }

    /// <summary>
    /// Дата окончания членства
    /// </summary>
    public DateTime MembershipEndDate { get; init; }

    /// <summary>
    /// Активен ли участник
    /// </summary>
    public bool IsActive { get; init; }
}
