using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Pharmacy.Prescriptions.DtoModels;

public sealed record UpdatePrescriptionDto
{
    /// <summary>
    /// Идентификатор рецепта
    /// </summary>
    [Required]
    public Guid IsnPrescription { get; init; }
    
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    public Guid IsnCustomer { get; init; }
    
    /// <summary>
    /// Идентификатор медикамента
    /// </summary>
    [Required]
    public Guid IsnMedication { get; init; }
    
    /// <summary>
    /// Номер рецепта
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Prescription.NumberMaxLength)]
    public string PrescriptionNumber { get; init; }
    
    /// <summary>
    /// Имя врача, выписавшего рецепт
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Prescription.DoctorNameMaxLength)]
    public string DoctorName { get; init; }
    
    /// <summary>
    /// Дозировка
    /// </summary>
    [Required]
    [Range(ModelConstants.Prescription.MinDosage, ModelConstants.Prescription.MaxDosage)]
    public int Dosage { get; init; }
    
    /// <summary>
    /// Инструкции по применению
    /// </summary>
    [MaxLength(ModelConstants.Prescription.InstructionsMaxLength)]
    public string Instructions { get; init; }
    
    /// <summary>
    /// Дата выписки рецепта
    /// </summary>
    [Required]
    public DateTime IssueDate { get; init; }
    
    /// <summary>
    /// Дата окончания действия рецепта
    /// </summary>
    [Required]
    public DateTime ExpiryDate { get; init; }
    
    /// <summary>
    /// Использован ли рецепт
    /// </summary>
    [Required]
    public bool IsUsed { get; init; }
}