namespace Lab3.Storage.Models.HospitalStore;

public class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnProduct { get; set; }  // Уникальный идентификатор

    [Required, MaxLength(ModelConstants.Product.NameMaxLength)]
    public string Name { get; set; }      // Название товара

    [Required, MaxLength(ModelConstants.Product.CategoryMaxLength)]
    public string Category { get; set; }  // "Medicine", "Equipment", etc.

    [Required, Range(ModelConstants.Product.PriceMin, ModelConstants.Product.PriceMax)]
    public int Price { get; set; }        // Цена в рублях (без копеек)
}