using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Pharmacy;

/// <summary>
/// Рецепт на медикамент
/// </summary>
public class Prescription
{
    /// <summary>
    /// Идентификатор рецепта
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPrescription { get; set; }
    
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    [ForeignKey(nameof(Customer))]
    public Guid IsnCustomer { get; set; }
    
    /// <summary>
    /// Идентификатор медикамента
    /// </summary>
    [Required]
    [ForeignKey(nameof(Medication))]
    public Guid IsnMedication { get; set; }
    
    /// <summary>
    /// Номер рецепта
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Prescription.NumberMaxLength)]
    public string PrescriptionNumber { get; set; }
    
    /// <summary>
    /// Имя врача, выписавшего рецепт
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Prescription.DoctorNameMaxLength)]
    public string DoctorName { get; set; }
    
    /// <summary>
    /// Дозировка
    /// </summary>
    [Required]
    [Range(ModelConstants.Prescription.MinDosage, ModelConstants.Prescription.MaxDosage)]
    public int Dosage { get; set; }
    
    /// <summary>
    /// Инструкции по применению
    /// </summary>
    [MaxLength(ModelConstants.Prescription.InstructionsMaxLength)]
    public string Instructions { get; set; }
    
    /// <summary>
    /// Дата выписки рецепта
    /// </summary>
    [Required]
    public DateTime IssueDate { get; set; }
    
    /// <summary>
    /// Дата окончания действия рецепта
    /// </summary>
    [Required]
    public DateTime ExpiryDate { get; set; }
    
    /// <summary>
    /// Использован ли рецепт
    /// </summary>
    [Required]
    public bool IsUsed { get; set; }
    
    /// <summary>
    /// Клиент
    /// </summary>
    public virtual PharmacyCustomer Customer { get; set; }
    
    /// <summary>
    /// Медикамент
    /// </summary>
    public virtual PharmacyMedication Medication { get; set; }
}