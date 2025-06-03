using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Restaurants;

/// <summary>
/// Заказ
/// </summary>
public class RestaurantOrder
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
    [MaxLength(ModelConstants.RestaurantOrder.OrderNumber)]
    public string OrderNumber { get; set; }

    /// <summary>
    /// Имя клиента
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.RestaurantOrder.CustomerName)]
    public string CustomerName { get; set; }

    /// <summary>
    /// Телефон клиента
    /// </summary>
    [MaxLength(ModelConstants.RestaurantOrder.CustomerPhone)]
    public string CustomerPhone { get; set; }

    /// <summary>
    /// Номер стола
    /// </summary>
    [Range(ModelConstants.RestaurantOrder.MinTableNumber, ModelConstants.RestaurantOrder.MaxTableNumber)]
    public int? TableNumber { get; set; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.RestaurantOrder.Status)]
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
    [InverseProperty(nameof(OrderItem.RestaurantOrder))]
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}