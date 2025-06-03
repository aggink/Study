using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.gegemonTV.DtoModels;

public sealed record CheckJsonResponseDto
{
    [JsonPropertyName("domains")]
    public List<string> Domains { get; init; }
    [JsonPropertyName("web_pages")]
    public List<string> WebPages { get; init; }
    [JsonPropertyName("state_province")]
    public object StateProvince { get; init; }
    [JsonPropertyName("alpha_two_code")]
    public string AlphaTwoCode { get; init; }
    [JsonPropertyName("name")]
    public string Name { get; init; }
    [JsonPropertyName("country")]
    public string Country { get; init; }
}


