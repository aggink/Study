using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Cinema;

/// <summary>
/// Клиент кинотеатра
/// </summary>
public class Customer
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnCustomer { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Customer.FirstName)]
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Customer.LastName)]
    public string LastName { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Customer.Email)]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Телефон
    /// </summary>
    [MaxLength(ModelConstants.Customer.Phone)]
    [Phone]
    public string Phone { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// Дата регистрации
    /// </summary>
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// Активен ли клиент
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Билеты клиента
    /// </summary>
    [InverseProperty(nameof(Ticket.Customer))]
    public virtual ICollection<Ticket> Tickets { get; set; }
}