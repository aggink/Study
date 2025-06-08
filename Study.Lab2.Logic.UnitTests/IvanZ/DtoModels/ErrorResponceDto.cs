using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.alkeivi.DtoModels;

public sealed record ErrorResponseDto
{
    [JsonPropertyName("message")]
    public string Message { get; init; }

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; init; }
}
