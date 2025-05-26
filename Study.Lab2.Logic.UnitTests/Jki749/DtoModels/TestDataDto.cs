using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.Jki749.DtoModels;

public sealed record TestDataDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }
}