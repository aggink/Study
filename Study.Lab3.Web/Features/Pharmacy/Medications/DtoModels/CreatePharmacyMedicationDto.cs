using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Pharmacy.Medications.DtoModels;

public sealed record CreatePharmacyMedicationDto
{
    /// <summary>
    /// Название медикамента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PharmacyMedication.NameMaxLength)]
    public string Name { get; init; }
    
    /// <summary>
    /// Описание медикамента
    /// </summary>
    [MaxLength(ModelConstants.PharmacyMedication.DescriptionMaxLength)]
    public string Description { get; init; }
    
    /// <summary>
    /// Производитель
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PharmacyMedication.ManufacturerMaxLength)]
    public string Manufacturer { get; init; }
    
    /// <summary>
    /// Цена медикамента
    /// </summary>
    [Required]
    [Range(ModelConstants.PharmacyMedication.MinPrice, ModelConstants.PharmacyMedication.MaxPrice)]
    public double Price { get; init; }
    
    /// <summary>
    /// Количество на складе
    /// </summary>
    [Required]
    [Range(ModelConstants.PharmacyMedication.MinQuantity, ModelConstants.PharmacyMedication.MaxQuantity)]
    public int QuantityInStock { get; init; }
    
    /// <summary>
    /// Требуется ли рецепт
    /// </summary>
    [Required]
    public bool RequiresPrescription { get; init; }
    
    /// <summary>
    /// Срок годности
    /// </summary>
    [Required]
    public DateTime ExpirationDate { get; init; }
}