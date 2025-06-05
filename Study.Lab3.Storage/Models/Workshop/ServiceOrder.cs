using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.Workshop;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Workshop;

/// <summary>
/// Заказ на услугу
/// </summary>
public class ServiceOrder
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnServiceOrder { get; set; }

    /// <summary>
    /// Идентификатор мастера
    /// </summary>
    [ForeignKey(nameof(Master))]
    public Guid IsnMaster { get; set; }

    /// <summary>
    /// Идентификатор услуги
    /// </summary>
    [ForeignKey(nameof(Service))]
    public Guid IsnService { get; set; }

    /// <summary>
    /// Имя клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.ServiceOrder.CustomerName)]
    public string CustomerName { get; set; }

    /// <summary>
    /// Телефон клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.ServiceOrder.CustomerPhone)]
    public string CustomerPhone { get; set; }

    /// <summary>
    /// Дата создания заказа
    /// </summary>
    [Required]
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    [Required]
    public OrderStatus Status { get; set; }

    /// <summary>
    /// Описание проблемы от клиента
    /// </summary>
    [MaxLength(ModelConstants.ServiceOrder.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Итоговая стоимость
    /// </summary>
    [Range(ModelConstants.ServiceOrder.MinTotalPrice, ModelConstants.ServiceOrder.MaxTotalPrice)]
    public double? TotalPrice { get; set; }

    /// <summary>
    /// Мастер, выполняющий заказ
    /// </summary>
    public virtual Master Master { get; set; }

    /// <summary>
    /// Услуга
    /// </summary>
    public virtual Service Service { get; set; }
}