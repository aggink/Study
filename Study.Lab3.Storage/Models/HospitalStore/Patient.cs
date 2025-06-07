using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.HospitalStore;

public class Patient
{
    /// <summary>
    /// Айди
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPatient { get; set; }

    /// <summary>
    /// ФИО пациента
    /// </summary>
    [Required, MaxLength(ModelConstants.Patient.FullNameMaxLength)]
    public string FullName { get; set; }

    /// <summary>
    /// Номер медкарты
    /// </summary>
    [Required, MaxLength(ModelConstants.Patient.MedicalCardIdMaxLength)]
    public string MedicalCardId { get; set; }

    /// <summary>
    /// Контактный телефон
    /// </summary>
    [Required, MaxLength(ModelConstants.Patient.PhoneMaxLength)]
    public string Phone { get; set; }

    [InverseProperty(nameof(Order.Patient))]
    public virtual ICollection<Order> Orders { get; set; }
}