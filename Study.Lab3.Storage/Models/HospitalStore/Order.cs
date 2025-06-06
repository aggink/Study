using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.HospitalStore;

public class Order
{
    /// <summary>
    /// Уникальный идентификатор заказа
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnOrder { get; set; }

    /// <summary>
    /// Идентификатор пациента
    /// </summary>
    [Required]
    [ForeignKey(nameof(Patient))]
    public Guid IsnPatient { get; set; }

    /// <summary>
    /// Идентификатор продукта
    /// </summary>
    [Required]
    [ForeignKey(nameof(Product))]
    public Guid IsnProduct { get; set; }

    /// <summary>
    /// Количество товара
    /// </summary>
    [Required, Range(ModelConstants.Order.QuantityMin, ModelConstants.Order.QuantityMax)]
    public int Quantity { get; set; }

    public virtual Patient Patient { get; set; }

    public virtual Product Product { get; set; }
}