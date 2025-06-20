using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.PetShop;

namespace Study.Lab3.Storage.Models.PetShop;

/// <summary>
/// Корм для животных
/// </summary>
public class PetFood
{
    /// <summary>
    /// Идентификатор корма
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPetFood { get; set; }

    /// <summary>
    /// Название корма
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PetFood.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Бренд
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PetFood.Brand)]
    public string Brand { get; set; }

    /// <summary>
    /// Тип корма
    /// </summary>
    [Required]
    public FoodType Type { get; set; }

    /// <summary>
    /// Для какого вида животных
    /// </summary>
    [Required]
    public PetSpecies TargetSpecies { get; set; }

    /// <summary>
    /// Вес упаковки в граммах
    /// </summary>
    [Range(ModelConstants.PetFood.WeightMin, ModelConstants.PetFood.WeightMax)]
    public int WeightInGrams { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    [Range(ModelConstants.PetFood.PriceMin, ModelConstants.PetFood.PriceMax)]
    public double Price { get; set; }

    /// <summary>
    /// Описание состава
    /// </summary>
    [MaxLength(ModelConstants.PetFood.Ingredients)]
    public string Ingredients { get; set; }

    /// <summary>
    /// Срок годности
    /// </summary>
    [Required]
    public DateTime ExpirationDate { get; set; }

    /// <summary>
    /// Количество в наличии
    /// </summary>
    [Range(ModelConstants.PetFood.StockMin, ModelConstants.PetFood.StockMax)]
    public int StockQuantity { get; set; }
}