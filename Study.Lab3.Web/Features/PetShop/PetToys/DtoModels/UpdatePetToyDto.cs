using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.PetShop.PetToys.DtoModels;

public sealed record UpdatePetToyDto
{
    [Required]
    public Guid IsnPetToy { get; init; }

    [Required, MaxLength(ModelConstants.PetToy.Name)]
    public string Name { get; init; }

    [MaxLength(ModelConstants.PetToy.Color)]
    public string Color { get; init; }

    [Range(ModelConstants.PetToy.PriceMin, ModelConstants.PetToy.PriceMax)]
    public double Price { get; init; }

    [MaxLength(ModelConstants.PetToy.Description)]
    public string Description { get; init; }

    [Range(ModelConstants.PetToy.StockMin, ModelConstants.PetToy.StockMax)]
    public int StockQuantity { get; init; }

    public bool IsSafe { get; init; }
}
