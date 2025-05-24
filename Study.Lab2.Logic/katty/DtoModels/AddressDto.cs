namespace Study.Lab2.Logic.katty.DtoModels;

public class AddressDto
{
    public string Street { get; }

    public string Suite { get; }

    public string City { get; }

    public string Zipcode { get; }

    public GeoDto Geo { get; }

    public AddressDto(string street, string suite, string city, string zipcode, GeoDto geo)
    {
        Street = street ?? string.Empty;
        Suite = suite ?? string.Empty;
        City = city ?? string.Empty;
        Zipcode = zipcode ?? string.Empty;
        Geo = geo;
    }
}