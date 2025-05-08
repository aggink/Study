using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.kinkiss1.DtoModels;
public class KanyeRestResponseDto
{
    [JsonPropertyName("quote")]
    public string Quote { get; init; }
}