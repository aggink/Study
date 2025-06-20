using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Museum;

/// <summary>
/// Посетитель музея
/// </summary>
public class MuseumVisitor
{
    /// <summary>
    /// Идентификатор посетителя
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnMuseumVisitor { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MuseumVisitor.FirstName)]
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MuseumVisitor.LastName)]
    public string LastName { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    [EmailAddress]
    [MaxLength(ModelConstants.MuseumVisitor.Email)]
    public string Email { get; set; }

    /// <summary>
    /// Телефон
    /// </summary>
    [Phone]
    [MaxLength(ModelConstants.MuseumVisitor.Phone)]
    public string Phone { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// Дата посещения
    /// </summary>
    [Required]
    public DateTime VisitDate { get; set; }

    /// <summary>
    /// Тип билета (взрослый, детский, студенческий, пенсионный)
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MuseumVisitor.TicketType)]
    public string TicketType { get; set; }

    /// <summary>
    /// Стоимость билета
    /// </summary>
    [Required]
    [Range(ModelConstants.MuseumVisitor.MinTicketPrice, ModelConstants.MuseumVisitor.MaxTicketPrice)]
    public double TicketPrice { get; set; }

    /// <summary>
    /// Является ли членом музея
    /// </summary>
    public bool IsMember { get; set; }

    /// <summary>
    /// Номер членского билета
    /// </summary>
    [MaxLength(ModelConstants.MuseumVisitor.MembershipNumber)]
    public string MembershipNumber { get; set; }
}