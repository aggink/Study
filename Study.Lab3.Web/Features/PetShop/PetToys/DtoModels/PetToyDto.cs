using Study.Lab3.Storage.Enums.PetShop;

namespace Study.Lab3.Web.Features.PetShop.PetToys.DtoModels;

public sealed record PetToyDto
{
    public Guid IsnPetToy { get; init; }
    public string Name { get; init; }
    public ToyMaterial Material { get; init; }
    public ToySize Size { get; init; }
    public PetSpecies TargetSpecies { get; init; }
    public string Color { get; init; }
    public double Price { get; init; }
    public string Description { get; init; }
    public PetAgeGroup AgeGroup { get; init; }
    public int StockQuantity { get; init; }
    public bool IsSafe { get; init; }
}
