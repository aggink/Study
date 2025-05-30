using System.ComponentModel.DataAnnotations;
using Lab3.Storage.Constants;

namespace Lab3.Storage.Models.HospitalStore;

public class Order
{
    public Guid IsnOrder { get; set; }    // ���������� ������������� ������

    public Guid IsnPatient { get; set; }  // ID �������� 

    public Guid IsnProduct { get; set; }  // ID ������ 

    [Required, Range(ModelConstants.Order.QuantityMin, ModelConstants.Order.QuantityMax)]
    public int Quantity { get; set; }     // ���������� ������
}