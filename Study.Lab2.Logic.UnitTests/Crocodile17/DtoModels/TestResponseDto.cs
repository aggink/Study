using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.Crocodile17.DtoModels;

public sealed record TestResponseDto
{
    [JsonPropertyName("message")]
    public string Message { get; init; }
}