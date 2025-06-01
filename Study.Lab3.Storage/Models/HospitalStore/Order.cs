using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.HospitalStore;

public class Order
{
    /// <summary>
    /// айди
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnOrder { get; set; }

    /// <summary>
    /// айди пациента
    /// </summary>
    [Required]
    public Guid IsnPatient { get; set; }

    /// <summary>
    /// айди товара
    /// </summary>
    [Required]
    public Guid IsnProduct { get; set; }

    /// <summary>
    /// количество товара
    /// </summary>
    [Required, Range(ModelConstants.Order.QuantityMin, ModelConstants.Order.QuantityMax)]
    public int Quantity { get; set; }
}