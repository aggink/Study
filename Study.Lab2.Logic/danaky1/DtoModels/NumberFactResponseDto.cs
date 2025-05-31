using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.danaky1.DtoModels;

public sealed record CountryInfoDto
{
    [JsonPropertyName("name")]
    public NameInfo Name { get; init; }

    [JsonPropertyName("capital")]
    public List<string> Capital { get; init; }

    [JsonPropertyName("population")]
    public long Population { get; init; }

    [JsonPropertyName("area")]
    public double Area { get; init; }

    [JsonPropertyName("continents")]
    public List<string> Continents { get; init; }
}

public sealed record NameInfo
{
    [JsonPropertyName("common")]
    public string Common { get; init; }

    [JsonPropertyName("official")]
    public string Official { get; init; }
}