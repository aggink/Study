namespace Lab3.Storage.Models.HospitalStore;

public class Product
{
    public Guid IsnProduct { get; set; }  // Уникальный идентификатор
    public string Name { get; set; }      // Название товара
    public string Category { get; set; }  // "Medicine", "Equipment", etc.
    public int Price { get; set; }        // Цена в рублях (без копеек)
}