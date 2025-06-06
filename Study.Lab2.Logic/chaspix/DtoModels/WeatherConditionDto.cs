using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.chaspix.DtoModels;

public sealed record WeatherConditionDto
{
    [JsonPropertyName("text")]
    public string Text { get; init; }
}
