using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Workshop;

/// <summary>
/// Услуга сервисного центра
/// </summary>
public class Service
{
    /// <summary>
    /// Идентификатор услуги
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnService { get; set; }

    /// <summary>
    /// Название услуги
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Service.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Описание услуги
    /// </summary>
    [MaxLength(ModelConstants.Service.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Цена услуги
    /// </summary>
    [Required]
    [Range(ModelConstants.Service.MinPrice, ModelConstants.Service.MaxPrice)]
    public double Price { get; set; }

    /// <summary>
    /// Длительность выполнения в минутах
    /// </summary>
    [Required]
    [Range(ModelConstants.Service.MinDuration, ModelConstants.Service.MaxDuration)]
    public int Duration { get; set; }

    /// <summary>
    /// Заказы по данной услуге
    /// </summary>
    [InverseProperty(nameof(ServiceOrder.Service))]
    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; }
}