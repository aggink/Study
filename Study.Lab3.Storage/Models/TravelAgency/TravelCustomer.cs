using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.TravelAgency;

/// <summary>
/// Клиент турагентства
/// </summary>
public class TravelCustomer
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnCustomer { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.TravelCustomer.SurName)]
    public string SurName { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.TravelCustomer.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    [MaxLength(ModelConstants.TravelCustomer.PatronymicName)]
    public string PatronymicName { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    [Required]
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.TravelCustomer.PassportNumber)]
    public string PassportNumber { get; set; }

    /// <summary>
    /// Телефон
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.TravelCustomer.Phone)]
    public string Phone { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.TravelCustomer.Email)]
    public string Email { get; set; }

    /// <summary>
    /// Адрес проживания
    /// </summary>
    [MaxLength(ModelConstants.TravelCustomer.Address)]
    public string Address { get; set; }

    /// <summary>
    /// Дата регистрации в системе
    /// </summary>
    [Required]
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// VIP клиент
    /// </summary>
    public bool IsVip { get; set; }
}