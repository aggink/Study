using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Storage.Models.HospitalStore;

public class Patient
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPatient { get; set; }  // Айди

    public string FullName { get; set; }  // ФИО пациента
    public string MedicalCardId { get; set; }  // Номер медкарты
    public string Phone { get; set; }     // Контактный телефон
}