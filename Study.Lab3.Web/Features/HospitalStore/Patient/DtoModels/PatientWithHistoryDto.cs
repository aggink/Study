namespace Study.Lab3.Web.Features.HospitalStore.Patient.DtoModels;

public sealed record PatientWithDetailsDto
{
    /// <summary>
    /// Идентификатор пациента
    /// </summary>
    public Guid IsnPatient { get; init; }

    /// <summary>
    /// ФИО пациента
    /// </summary>
    public string FullName { get; init; }

    /// <summary>
    /// Номер медицинской карты
    /// </summary>
    public string MedicalCardId { get; init; }

    /// <summary>
    /// Контактный телефон
    /// </summary>
    public string Phone { get; init; }

    /// <summary>
    /// Количество заказов пациента
    /// </summary>
    public int TotalOrders { get; init; }

    /// <summary>
    /// Дата последнего заказа
    /// </summary>
    public DateTime? LastOrderDate { get; init; }
}
