using System.ComponentModel.DataAnnotations;
using Lab3.Storage.Constants;

namespace Lab3.Storage.Models.HospitalStore;

public class Order
{
    public Guid IsnOrder { get; set; }    // Уникальный идентификатор заказа

    public Guid IsnPatient { get; set; }  // ID пациента 

    public Guid IsnProduct { get; set; }  // ID товара 

    [Required, Range(ModelConstants.Order.QuantityMin, ModelConstants.Order.QuantityMax)]
    public int Quantity { get; set; }     // Количество товара
}