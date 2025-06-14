namespace Study.Lab3.Web.Features.Shelter.MiniPigAdoptions.DtoModels;

public sealed record AdoptionDto
{
    public Guid IsnAdoption { get; init; }

    public int Price { get; init; }

    public Guid IsnCustomer { get; init; }

    public Guid IsnMiniPig { get; init; }

    public DateTime AdoptionDate { get; init; }

    public string Status { get; init; }
}