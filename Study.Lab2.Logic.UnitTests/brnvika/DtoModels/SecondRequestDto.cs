using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.brnvika.DtoModels;

public class SecondRequestDto
{
    [JsonPropertyName("copyright")]
    public string Copyright { get; set; }

    public string date { get; set; }

    public string explanation { get; set; }

    public string hdurl { get; set; }

    public string media_type { get; set; }

    public string service_version { get; set; }

    public string title { get; set; }

    public string url { get; set; }
}
