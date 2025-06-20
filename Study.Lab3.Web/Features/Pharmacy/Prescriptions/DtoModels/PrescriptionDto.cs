namespace Study.Lab3.Web.Features.Pharmacy.Prescriptions.DtoModels;

public sealed record PrescriptionDto
{
    /// <summary>
    /// Идентификатор рецепта
    /// </summary>
    public Guid IsnPrescription { get; init; }
    
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid IsnCustomer { get; init; }
    
    /// <summary>
    /// Идентификатор медикамента
    /// </summary>
    public Guid IsnMedication { get; init; }
    
    /// <summary>
    /// Номер рецепта
    /// </summary>
    public string PrescriptionNumber { get; init; }
    
    /// <summary>
    /// Имя врача, выписавшего рецепт
    /// </summary>
    public string DoctorName { get; init; }
    
    /// <summary>
    /// Дозировка
    /// </summary>
    public int Dosage { get; init; }
    
    /// <summary>
    /// Инструкции по применению
    /// </summary>
    public string Instructions { get; init; }
    
    /// <summary>
    /// Дата выписки рецепта
    /// </summary>
    public DateTime IssueDate { get; init; }
    
    /// <summary>
    /// Дата окончания действия рецепта
    /// </summary>
    public DateTime ExpiryDate { get; init; }
    
    /// <summary>
    /// Использован ли рецепт
    /// </summary>
    public bool IsUsed { get; init; }
}