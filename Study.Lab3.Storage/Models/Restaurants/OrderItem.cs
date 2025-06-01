using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Restaurants;

/// <summary>
/// Позиция заказа
/// </summary>
public class OrderItem
{
    /// <summary>
    /// Идентификатор позиции заказа
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnOrderItem { get; set; }

    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    [ForeignKey(nameof(Order))]
    public Guid IsnOrder { get; set; }

    /// <summary>
    /// Идентификатор позиции меню
    /// </summary>
    [ForeignKey(nameof(MenuItem))]
    public Guid IsnMenuItem { get; set; }

    /// <summary>
    /// Количество
    /// </summary>
    [Required]
    [Range(ModelConstants.OrderItem.MinQuantity, ModelConstants.OrderItem.MaxQuantity)]
    public int Quantity { get; set; }

    /// <summary>
    /// Цена за единицу на момент заказа
    /// </summary>
    [Required]
    public double UnitPrice { get; set; }

    /// <summary>
    /// Общая стоимость позиции
    /// </summary>
    public double TotalPrice { get; set; }

    /// <summary>
    /// Особые пожелания к блюду
    /// </summary>
    [MaxLength(ModelConstants.OrderItem.SpecialRequests)]
    public string SpecialRequests { get; set; }

    /// <summary>
    /// Заказ
    /// </summary>
    public virtual Order Order { get; set; }

    /// <summary>
    /// Позиция меню
    /// </summary>
    public virtual MenuItem MenuItem { get; set; }
}