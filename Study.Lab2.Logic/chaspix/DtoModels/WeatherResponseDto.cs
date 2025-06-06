using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.chaspix.DtoModels;

/// <summary>
/// DTO для ответа о погоде
/// </summary>
public sealed record WeatherResponseDto
{
    [JsonPropertyName("location")]
    public LocationDto Location { get; init; }

    [JsonPropertyName("current")]
    public CurrentWeatherDto Current { get; init; }
}