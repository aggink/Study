using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.PetShop;

namespace Study.Lab3.Web.Features.PetShop.PetFoods.DtoModels;

/// <summary>
/// DTO для создания корма
/// </summary>
public sealed record CreatePetFoodDto
{
    /// <summary>
    /// Название корма
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PetFood.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Бренд
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PetFood.Brand)]
    public string Brand { get; init; }

    /// <summary>
    /// Тип корма
    /// </summary>
    [Required]
    public FoodType Type { get; init; }

    /// <summary>
    /// Для какого вида животных
    /// </summary>
    [Required]
    public PetSpecies TargetSpecies { get; init; }

    /// <summary>
    /// Вес упаковки в граммах
    /// </summary>
    [Range(ModelConstants.PetFood.WeightMin, ModelConstants.PetFood.WeightMax)]
    public int WeightInGrams { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    [Range(ModelConstants.PetFood.PriceMin, ModelConstants.PetFood.PriceMax)]
    public double Price { get; init; }

    /// <summary>
    /// Описание состава
    /// </summary>
    [MaxLength(ModelConstants.PetFood.Ingredients)]
    public string Ingredients { get; init; }

    /// <summary>
    /// Срок годности
    /// </summary>
    [Required]
    public DateTime ExpirationDate { get; init; }

    /// <summary>
    /// Количество в наличии
    /// </summary>
    [Range(ModelConstants.PetFood.StockMin, ModelConstants.PetFood.StockMax)]
    public int StockQuantity { get; init; }
}
