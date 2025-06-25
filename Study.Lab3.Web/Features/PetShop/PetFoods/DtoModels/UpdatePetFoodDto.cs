using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.PetShop.PetFoods.DtoModels;

/// <summary>
/// DTO для обновления корма
/// </summary>
public sealed record UpdatePetFoodDto
{
    /// <summary>
    /// Идентификатор корма
    /// </summary>
    [Required]
    public Guid IsnPetFood { get; init; }

    /// <summary>
    /// Название корма
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PetFood.Name)]
    public string Name { get; init; }

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