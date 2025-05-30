using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Lab3.Storage.Models.HospitalStore;

public class Patient
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPatient { get; set; }  // ����

    [Required, MaxLength(ModelConstants.Patient.FullNameMaxLength)]
    public string FullName { get; set; }  // ��� ��������

    [Required, MaxLength(ModelConstants.Patient.MedicalCardIdMaxLength)]
    public string MedicalCardId { get; set; }  // ����� ��������

    [Required, MaxLength(ModelConstants.Patient.PhoneMaxLength)]
    public string Phone { get; set; }     // ���������� �������
}