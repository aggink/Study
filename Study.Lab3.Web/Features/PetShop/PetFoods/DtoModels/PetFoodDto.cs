using Study.Lab3.Storage.Enums.PetShop;

namespace Study.Lab3.Web.Features.PetShop.PetFoods.DtoModels;

/// <summary>
/// DTO для чтения корма
/// </summary>
public sealed record PetFoodDto
{
    /// <summary>
    /// Идентификатор корма
    /// </summary>
    public Guid IsnPetFood { get; init; }

    /// <summary>
    /// Название корма
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Бренд
    /// </summary>
    public string Brand { get; init; }

    /// <summary>
    /// Тип корма
    /// </summary>
    public FoodType Type { get; init; }

    /// <summary>
    /// Для какого вида животных
    /// </summary>
    public PetSpecies TargetSpecies { get; init; }

    /// <summary>
    /// Вес упаковки в граммах
    /// </summary>
    public int WeightInGrams { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; init; }

    /// <summary>
    /// Описание состава
    /// </summary>
    public string Ingredients { get; init; }

    /// <summary>
    /// Срок годности
    /// </summary>
    public DateTime ExpirationDate { get; init; }

    /// <summary>
    /// Количество в наличии
    /// </summary>
    public int StockQuantity { get; init; }
}