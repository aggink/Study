using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.Pro100futa.DtoModels;

public sealed record RandomJokesResponseDto
{
	[JsonPropertyName("data")]
	public List<string> Data { get; init; }
}
