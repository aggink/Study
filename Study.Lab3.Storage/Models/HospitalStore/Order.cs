namespace Lab3.Storage.Models.HospitalStore;

public class Order
{
    public Guid IsnOrder { get; set; }    // ���������� ������������� ������
    public Guid IsnPatient { get; set; }  // ID �������� 
    public Guid IsnProduct { get; set; }  // ID ������ 
    public int Quantity { get; set; }     // ���������� ������
}