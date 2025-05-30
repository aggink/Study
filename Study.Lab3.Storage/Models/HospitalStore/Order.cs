using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Lab3.Storage.Models.HospitalStore;

public class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnOrder { get; set; }    // ���������� ������������� ������

    [Required]
    public Guid IsnPatient { get; set; }  // ID �������� 

    [Required]
    public Guid IsnProduct { get; set; }  // ID ������ 

    [Required, Range(ModelConstants.Order.QuantityMin, ModelConstants.Order.QuantityMax)]
    public int Quantity { get; set; }     // ���������� ������
}