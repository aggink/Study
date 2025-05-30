using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Lab3.Storage.Models.HospitalStore;

public class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnOrder { get; set; }    // Уникальный идентификатор заказа

    [Required]
    public Guid IsnPatient { get; set; }  // ID пациента 

    [Required]
    public Guid IsnProduct { get; set; }  // ID товара 

    [Required, Range(ModelConstants.Order.QuantityMin, ModelConstants.Order.QuantityMax)]
    public int Quantity { get; set; }     // Количество товара
}