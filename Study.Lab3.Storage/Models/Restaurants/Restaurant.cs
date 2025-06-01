using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Restaurants;

/// <summary>
/// Ресторан
/// </summary>
public class Restaurant
{
    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnRestaurant { get; set; }

    /// <summary>
    /// Название ресторана
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Restaurant.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Адрес
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Restaurant.Address)]
    public string Address { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [MaxLength(ModelConstants.Restaurant.Phone)]
    public string Phone { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    [MaxLength(ModelConstants.Restaurant.Email)]
    public string Email { get; set; }

    /// <summary>
    /// Время работы
    /// </summary>
    [MaxLength(ModelConstants.Restaurant.WorkingHours)]
    public string WorkingHours { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Меню ресторана
    /// </summary>
    [InverseProperty(nameof(Menu.Restaurant))]
    public virtual ICollection<Menu> Menus { get; set; }

    /// <summary>
    /// Заказы ресторана
    /// </summary>
    [InverseProperty(nameof(Order.Restaurant))]
    public virtual ICollection<Order> Orders { get; set; }
}