using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.PetShop;

namespace Study.Lab3.Web.Features.PetShop.PetToys.DtoModels;

/// <summary>
/// DTO для создания игрушки
/// </summary>
public sealed record CreatePetToyDto
{
    [Required, MaxLength(ModelConstants.PetToy.Name)]
    public string Name { get; init; }

    [Required]
    public ToyMaterial Material { get; init; }

    [Required]
    public ToySize Size { get; init; }

    [Required]
    public PetSpecies TargetSpecies { get; init; }

    [MaxLength(ModelConstants.PetToy.Color)]
    public string Color { get; init; }

    [Range(ModelConstants.PetToy.PriceMin, ModelConstants.PetToy.PriceMax)]
    public double Price { get; init; }

    [MaxLength(ModelConstants.PetToy.Description)]
    public string Description { get; init; }

    [Required]
    public PetAgeGroup AgeGroup { get; init; }

    [Range(ModelConstants.PetToy.StockMin, ModelConstants.PetToy.StockMax)]
    public int StockQuantity { get; init; }

    public bool IsSafe { get; init; } = true;
}