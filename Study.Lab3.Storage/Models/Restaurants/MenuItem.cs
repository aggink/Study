using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Restaurants;

/// <summary>
/// Позиция меню
/// </summary>
public class MenuItem
{
    /// <summary>
    /// Идентификатор позиции меню
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnMenuItem { get; set; }

    /// <summary>
    /// Идентификатор меню
    /// </summary>
    [ForeignKey(nameof(Menu))]
    public Guid IsnMenu { get; set; }

    /// <summary>
    /// Название блюда
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MenuItem.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Описание блюда
    /// </summary>
    [MaxLength(ModelConstants.MenuItem.Description)]
    public string Description { get; set; }
    
    /// <summary>
    /// Категория блюда
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MenuItem.Category)]
    public string  Category { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    [Required]
    [Range(ModelConstants.MenuItem.MinPrice, ModelConstants.MenuItem.MaxPrice)]
    public double Price { get; set; }

    /// <summary>
    /// Доступность блюда
    /// </summary>
    public bool IsAvailable { get; set; }

    /// <summary>
    /// Время приготовления в минутах
    /// </summary>
    [Range(ModelConstants.MenuItem.MinCookingTime, ModelConstants.MenuItem.MaxCookingTime)]
    public int CookingTimeMinutes { get; set; }

    /// <summary>
    /// Меню
    /// </summary>
    public virtual Menu Menu { get; set; }

    /// <summary>
    /// Позиции заказов с этим блюдом
    /// </summary>
    [InverseProperty(nameof(OrderItem.MenuItem))]
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}
