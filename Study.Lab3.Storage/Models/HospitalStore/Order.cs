namespace Lab3.Storage.Models.HospitalStore;

public class Order
{
    public Guid IsnOrder { get; set; }    // Уникальный идентификатор заказа
    public Guid IsnPatient { get; set; }  // ID пациента 
    public Guid IsnProduct { get; set; }  // ID товара 
    public int Quantity { get; set; }     // Количество товара
}