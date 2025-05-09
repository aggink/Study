using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.brnvika.DtoModels;

public class SecondRequestDto
{
    [JsonPropertyName("copyright")]
    public string Copyright { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("explanation")]
    public string Explanation { get; set; }

    [JsonPropertyName("hdurl")]
    public string Hdurl { get; set; }

    [JsonPropertyName("media_type")]
    public string MediaType { get; set; }

    [JsonPropertyName("service_version")]
    public string ServiceVersion { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
