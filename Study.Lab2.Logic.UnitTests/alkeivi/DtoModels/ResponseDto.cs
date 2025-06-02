using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.alkeivi.DtoModels;

public sealed record ResponseDto
{
    [JsonPropertyName("message")]
    public string Message { get; init; }
}
