using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.chaspix.DtoModels;

public sealed record LocationDto
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("country")]
    public string Country { get; init; }

    [JsonPropertyName("localtime")]
    public string LocalTime { get; init; }
}
