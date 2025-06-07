using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.chaspix.DtoModels;

/// <summary>
/// DTO для факта о кошках
/// </summary>
public sealed record CatFactDto
{
    [JsonPropertyName("fact")]
    public string Fact { get; init; }

    [JsonPropertyName("length")]
    public int Length { get; init; }
}