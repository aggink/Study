using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Pharmacy;

/// <summary>
/// Клиент аптеки
/// </summary>
public class PharmacyCustomer
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnCustomer { get; set; }
    
    /// <summary>
    /// Имя клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PharmacyCustomer.FirstNameMaxLength)]
    public string FirstName { get; set; }
    
    /// <summary>
    /// Фамилия клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PharmacyCustomer.LastNameMaxLength)]
    public string LastName { get; set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    [MaxLength(ModelConstants.PharmacyCustomer.PhoneMaxLength)]
    public string Phone { get; set; }
    
    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    [MaxLength(ModelConstants.PharmacyCustomer.EmailMaxLength)]
    public string Email { get; set; }
    
    /// <summary>
    /// Адрес
    /// </summary>
    [MaxLength(ModelConstants.PharmacyCustomer.AddressMaxLength)]
    public string Address { get; set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? DateOfBirth { get; set; }
    
    /// <summary>
    /// Дата регистрации
    /// </summary>
    [Required]
    public DateTime RegistrationDate { get; set; }
    
    /// <summary>
    /// Есть ли медицинская страховка
    /// </summary>
    [Required]
    public bool HasInsurance { get; set; }
    
    /// <summary>
    /// Рецепты клиента
    /// </summary>
    [InverseProperty(nameof(Prescription.Customer))]
    public virtual ICollection<Prescription> Prescriptions { get; set; }
}