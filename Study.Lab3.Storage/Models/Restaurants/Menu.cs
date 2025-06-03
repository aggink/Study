using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Restaurants;

/// <summary>
/// Меню ресторана
/// </summary>
public class Menu
{
    /// <summary>
    /// Идентификатор меню
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnMenu { get; set; }

    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    [ForeignKey(nameof(Restaurant))]
    public Guid IsnRestaurant { get; set; }

    /// <summary>
    /// Название меню
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Menu.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    [MaxLength(ModelConstants.Menu.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Активность меню
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Ресторан
    /// </summary>
    public virtual Restaurant Restaurant { get; set; }

    /// <summary>
    /// Позиции меню
    /// </summary>
    [InverseProperty(nameof(MenuItem.Menu))]
    public virtual ICollection<MenuItem> MenuItems { get; set; }
}
