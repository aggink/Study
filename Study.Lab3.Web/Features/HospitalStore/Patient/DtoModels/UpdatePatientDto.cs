using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.HospitalStore.Patient.DtoModels;

public sealed record UpdatePatientDto
{
    /// <summary>
    /// Идентификатор пациента
    /// </summary>
    [Required]
    public Guid IsnPatient { get; init; }

    /// <summary>
    /// ФИО пациента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Patient.FullNameMaxLength)]
    public string FullName { get; init; }

    /// <summary>
    /// Номер медицинской карты
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Patient.MedicalCardIdMaxLength)]
    public string MedicalCardId { get; init; }

    /// <summary>
    /// Контактный телефон
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Patient.PhoneMaxLength)]
    public string Phone { get; init; }
}
