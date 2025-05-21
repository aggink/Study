using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.poigko.DtoModels;

public sealed record CatFactResponseDto
{
    [JsonPropertyName("data")]
    public List<string> Data { get; init; }
}
