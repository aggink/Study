using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.chaspix.DtoModels;

public sealed record CurrentWeatherDto
{
    [JsonPropertyName("temp_c")]
    public decimal TemperatureCelsius { get; init; }

    [JsonPropertyName("condition")]
    public WeatherConditionDto Condition { get; init; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; init; }

    [JsonPropertyName("wind_kph")]
    public decimal WindSpeed { get; init; }
}
