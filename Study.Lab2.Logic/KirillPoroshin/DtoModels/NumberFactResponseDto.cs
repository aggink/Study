using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.KirillPoroshin.DtoModels;

public sealed record NumberFactResponseDto
{
    [JsonPropertyName("text")]
    public string Text { get; init; } = string.Empty;

    [JsonPropertyName("number")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)] 
    public int Number { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;
}