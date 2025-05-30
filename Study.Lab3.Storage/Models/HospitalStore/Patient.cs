using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.HospitalStore;

public class Patient
{
    /// <summary>
    /// ����
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPatient { get; set; }

    /// <summary>
    /// ��� ��������
    /// </summary>
    [Required, MaxLength(ModelConstants.Patient.FullNameMaxLength)]
    public string FullName { get; set; }

    /// <summary>
    /// ����� ��������
    /// </summary>
    [Required, MaxLength(ModelConstants.Patient.MedicalCardIdMaxLength)]
    public string MedicalCardId { get; set; }

    /// <summary>
    /// ���������� �������
    /// </summary>
    [Required, MaxLength(ModelConstants.Patient.PhoneMaxLength)]
    public string Phone { get; set; }     
}