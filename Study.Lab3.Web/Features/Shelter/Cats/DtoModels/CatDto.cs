using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.Shelter.Cats.DtoModels;

public sealed record CatDto
{
    public Guid IsnCat { get; init; }

    public string Nickname { get; init; }

    public DateTime? BirthDate { get; init; }

    public string Description { get; init; }

    public string Breed { get; init; }

    public bool IsVaccinated { get; init; }

    public bool IsSterilized { get; init; }

    public string Color { get; init; }

    public string MedicalHistory { get; init; }

    public string PhotoUrl { get; init; }

    public DateTime ArrivalDate { get; init; }

    public bool IsAvailableForAdoption { get; init; }

    public int Age { get; init; }

    public int Weight { get; init; }
}