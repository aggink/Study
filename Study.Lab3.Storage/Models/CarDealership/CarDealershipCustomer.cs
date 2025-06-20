using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.CarDealership;

/// <summary>
/// Клиент автосалона
/// </summary>
public class CarDealershipCustomer
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
    [MaxLength(ModelConstants.CarDealershipCustomer.FirstName)]
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.CarDealershipCustomer.LastName)]
    public string LastName { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.CarDealershipCustomer.Email)]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Телефон
    /// </summary>
    [MaxLength(ModelConstants.CarDealershipCustomer.Phone)]
    [Phone]
    public string Phone { get; set; }

    /// <summary>
    /// Адрес
    /// </summary>
    [MaxLength(ModelConstants.CarDealershipCustomer.Address)]
    public string Address { get; set; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.CarDealershipCustomer.PassportNumber)]
    public string PassportNumber { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// Дата регистрации
    /// </summary>
    [Required]
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// Продажи клиента
    /// </summary>
    [InverseProperty(nameof(CarDealershipSale.Customer))]
    public virtual ICollection<CarDealershipSale> Sales { get; set; }
}