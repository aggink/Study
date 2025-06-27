using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Pharmacy;

/// <summary>
/// Медикамент в аптеке
/// </summary>
public class PharmacyMedication
{
    /// <summary>
    /// Идентификатор медикамента
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnMedication { get; set; }
    
    /// <summary>
    /// Название медикамента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PharmacyMedication.NameMaxLength)]
    public string Name { get; set; }
    
    /// <summary>
    /// Описание медикамента
    /// </summary>
    [MaxLength(ModelConstants.PharmacyMedication.DescriptionMaxLength)]
    public string Description { get; set; }
    
    /// <summary>
    /// Производитель
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PharmacyMedication.ManufacturerMaxLength)]
    public string Manufacturer { get; set; }
    
    /// <summary>
    /// Цена медикамента
    /// </summary>
    [Required]
    [Range(ModelConstants.PharmacyMedication.MinPrice, ModelConstants.PharmacyMedication.MaxPrice)]
    public double Price { get; set; }
    
    /// <summary>
    /// Количество на складе
    /// </summary>
    [Required]
    [Range(ModelConstants.PharmacyMedication.MinQuantity, ModelConstants.PharmacyMedication.MaxQuantity)]
    public int QuantityInStock { get; set; }
    
    /// <summary>
    /// Требуется ли рецепт
    /// </summary>
    [Required]
    public bool RequiresPrescription { get; set; }
    
    /// <summary>
    /// Срок годности
    /// </summary>
    [Required]
    public DateTime ExpirationDate { get; set; }
    
    /// <summary>
    /// Дата поступления на склад
    /// </summary>
    [Required]
    public DateTime ReceiptDate { get; set; }
    
    /// <summary>
    /// Рецепты на этот медикамент
    /// </summary>
    [InverseProperty(nameof(Prescription.Medication))]
    public virtual ICollection<Prescription> Prescriptions { get; set; }
}