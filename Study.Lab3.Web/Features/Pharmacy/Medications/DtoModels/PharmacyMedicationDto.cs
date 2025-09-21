namespace Study.Lab3.Web.Features.Pharmacy.Medications.DtoModels;

public sealed record PharmacyMedicationDto
{
    /// <summary>
    /// Идентификатор медикамента
    /// </summary>
    public Guid IsnMedication { get; init; }
    
    /// <summary>
    /// Название медикамента
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// Описание медикамента
    /// </summary>
    public string Description { get; init; }
    
    /// <summary>
    /// Производитель
    /// </summary>
    public string Manufacturer { get; init; }
    
    /// <summary>
    /// Цена медикамента
    /// </summary>
    public double Price { get; init; }
    
    /// <summary>
    /// Количество на складе
    /// </summary>
    public int QuantityInStock { get; init; }
    
    /// <summary>
    /// Требуется ли рецепт
    /// </summary>
    public bool RequiresPrescription { get; init; }
    
    /// <summary>
    /// Срок годности
    /// </summary>
    public DateTime ExpirationDate { get; init; }
    
    /// <summary>
    /// Дата поступления на склад
    /// </summary>
    public DateTime ReceiptDate { get; init; }
}