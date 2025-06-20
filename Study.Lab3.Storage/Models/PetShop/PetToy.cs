using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.PetShop;

namespace Study.Lab3.Storage.Models.PetShop;

/// <summary>
/// Игрушка для животных
/// </summary>
public class PetToy
{
    /// <summary>
    /// Идентификатор игрушки
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPetToy { get; set; }

    /// <summary>
    /// Название игрушки
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PetToy.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Материал изготовления
    /// </summary>
    [Required]
    public ToyMaterial Material { get; set; }

    /// <summary>
    /// Размер игрушки
    /// </summary>
    [Required]
    public ToySize Size { get; set; }

    /// <summary>
    /// Для какого вида животных
    /// </summary>
    [Required]
    public PetSpecies TargetSpecies { get; set; }

    /// <summary>
    /// Цвет
    /// </summary>
    [MaxLength(ModelConstants.PetToy.Color)]
    public string Color { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    [Range(ModelConstants.PetToy.PriceMin, ModelConstants.PetToy.PriceMax)]
    public double Price { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    [MaxLength(ModelConstants.PetToy.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Возрастная группа животных
    /// </summary>
    [Required]
    public PetAgeGroup AgeGroup { get; set; }

    /// <summary>
    /// Количество в наличии
    /// </summary>
    [Range(ModelConstants.PetToy.StockMin, ModelConstants.PetToy.StockMax)]
    public int StockQuantity { get; set; }

    /// <summary>
    /// Безопасна ли для животных
    /// </summary>
    [Required]
    public bool IsSafe { get; set; }
}