using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.chirique_online.DtoModels;

public sealed record ResponseDto
{
    [JsonPropertyName("message")]
    public string Message { get; init; }
}
