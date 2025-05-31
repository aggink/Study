using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.gegemonTV.DtoModels;

public sealed record TestResponseDto
{
    [JsonPropertyName("message")]
    public string Message { get; init; }
}
