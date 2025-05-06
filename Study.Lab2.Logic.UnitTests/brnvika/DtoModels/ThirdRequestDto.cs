using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.brnvika.DtoModels;

public class ThirdRequestDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("state-province")]
    public string StateProvince { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("alpha_two_code")]
    public string AlphaTwoCode { get; set; }

    [JsonPropertyName("web_pages")]
    public List<string> WebPages { get; set; }

    [JsonPropertyName("domains")]
    public List<string> Domains { get; set; }
}