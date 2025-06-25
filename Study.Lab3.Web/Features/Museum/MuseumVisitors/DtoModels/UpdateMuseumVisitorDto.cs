using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Museum.MuseumVisitors.DtoModels;

public sealed record UpdateMuseumVisitorDto
{
    /// <summary>
    /// Идентификатор посетителя
    /// </summary>
    [Required]
    public Guid IsnMuseumVisitor { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MuseumVisitor.FirstName)]
    public string FirstName { get; init; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MuseumVisitor.LastName)]
    public string LastName { get; init; }

    /// <summary>
    /// Email
    /// </summary>
    [EmailAddress]
    [MaxLength(ModelConstants.MuseumVisitor.Email)]
    public string Email { get; init; }

    /// <summary>
    /// Телефон
    /// </summary>
    [Phone]
    [MaxLength(ModelConstants.MuseumVisitor.Phone)]
    public string Phone { get; init; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? DateOfBirth { get; init; }

    /// <summary>
    /// Дата посещения
    /// </summary>
    [Required]
    public DateTime VisitDate { get; init; }

    /// <summary>
    /// Тип билета
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MuseumVisitor.TicketType)]
    public string TicketType { get; init; }

    /// <summary>
    /// Стоимость билета
    /// </summary>
    [Required]
    [Range(ModelConstants.MuseumVisitor.MinTicketPrice, ModelConstants.MuseumVisitor.MaxTicketPrice)]
    public double TicketPrice { get; init; }

    /// <summary>
    /// Является ли членом музея
    /// </summary>
    public bool IsMember { get; init; }

    /// <summary>
    /// Номер членского билета
    /// </summary>
    [MaxLength(ModelConstants.MuseumVisitor.MembershipNumber)]
    public string MembershipNumber { get; init; }
}
