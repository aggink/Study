using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.Jki749.DtoModels;

public sealed record TestUserDto
{
    [JsonPropertyName("name")]
    public string Name { get; init; }
}