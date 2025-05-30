namespace Study.Lab2.Logic.katty.DtoModels;

public class GeoDto
{
    public string Lat { get; }

    public string Lng { get; }

    public GeoDto(string lat, string lng)
    {
        Lat = lat ?? string.Empty;
        Lng = lng ?? string.Empty;
    }
}