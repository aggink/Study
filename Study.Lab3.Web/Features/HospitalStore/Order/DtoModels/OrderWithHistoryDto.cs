namespace Study.Lab3.Web.Features.HospitalStore.Order.DtoModels;

public sealed record OrderWithDetailsDto
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid IsnOrder { get; init; }

    /// <summary>
    /// Идентификатор пациента
    /// </summary>
    public Guid IsnPatient { get; init; }

    /// <summary>
    /// ФИО пациента
    /// </summary>
    public string PatientFullName { get; init; }

    /// <summary>
    /// Идентификатор продукта
    /// </summary>
    public Guid IsnProduct { get; init; }

    /// <summary>
    /// Название продукта
    /// </summary>
    public string ProductName { get; init; }

    /// <summary>
    /// Количество заказанного товара
    /// </summary>
    public int Quantity { get; init; }

    /// <summary>
    /// Дата заказа
    /// </summary>
    public DateTime OrderDate { get; init; }
}
