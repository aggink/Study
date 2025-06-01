using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Restaurants;

/// <summary>
/// Заказ
/// </summary>
public class Order
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnOrder { get; set; }

    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    [ForeignKey(nameof(Restaurant))]
    public Guid IsnRestaurant { get; set; }

    /// <summary>
    /// Номер заказа
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Order.OrderNumber)]
    public string OrderNumber { get; set; }

    /// <summary>
    /// Имя клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Order.CustomerName)]
    public string CustomerName { get; set; }

    /// <summary>
    /// Телефон клиента
    /// </summary>
    [MaxLength(ModelConstants.Order.CustomerPhone)]
    public string CustomerPhone { get; set; }

    /// <summary>
    /// Номер стола
    /// </summary>
    [Range(ModelConstants.Order.MinTableNumber, ModelConstants.Order.MaxTableNumber)]
    public int? TableNumber { get; set; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Order.Status)]
    public string Status { get; set; }

    /// <summary>
    /// Общая сумма заказа
    /// </summary>
    public double TotalAmount { get; set; }

    /// <summary>
    /// Дата создания заказа
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Дата завершения заказа
    /// </summary>
    public DateTime? CompletedDate { get; set; }

    /// <summary>
    /// Ресторан
    /// </summary>
    public virtual Restaurant Restaurant { get; set; }

    /// <summary>
    /// Позиции заказа
    /// </summary>
    [InverseProperty(nameof(OrderItem.Order))]
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}