using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.HospitalStore;

public class Product
{
    /// <summary>
    /// айди
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnProduct { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    [Required, MaxLength(ModelConstants.Product.NameMaxLength)]
    public string Name { get; set; }

    /// <summary>
    /// Категория: "Medicine", "Equipment", etc.
    /// </summary>
    [Required, MaxLength(ModelConstants.Product.CategoryMaxLength)]
    public string Category { get; set; }

    /// <summary>
    /// Цена в рублях (без копеек)
    /// </summary>
    [Required, Range(ModelConstants.Product.PriceMin, ModelConstants.Product.PriceMax)]
    public int Price { get; set; }

    [InverseProperty(nameof(Order.Product))]
    public virtual ICollection<Order> Orders { get; set; }
}