namespace Study.Lab3.Web.Features.HospitalStore.Patient.DtoModels;
public sealed record PatientDto
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
}
