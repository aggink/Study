using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Storage.Models.HospitalStore;

public class Patient
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPatient { get; set; }  // ����

    public string FullName { get; set; }  // ��� ��������
    public string MedicalCardId { get; set; }  // ����� ��������
    public string Phone { get; set; }     // ���������� �������
}