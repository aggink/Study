namespace Study.Lab3.Web.Features.Formula1.Drivers.DtoModels;

public class DriverDto
{
    public Guid IsnDriver { get; init; }
    public Guid IsnTeam { get; init; }
    public string Name { get; init; }
    public int Age { get; init; }
    public string CountryOfOrigin { get; init; }
}
