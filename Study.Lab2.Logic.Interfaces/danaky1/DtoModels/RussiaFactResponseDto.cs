using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.Interfaces.danaky1.DtoModels;

public sealed record RussiaFactResponseDto
{
    [JsonPropertyName("fact")]
    public string Fact { get; init; }
}
