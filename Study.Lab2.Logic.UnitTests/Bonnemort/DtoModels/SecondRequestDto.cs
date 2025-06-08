using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.UnitTests.Bonnemort.DtoModels;

public class QuoteDto
{
    [JsonPropertyName("content")]
    public string Content { get; set; }
    [JsonPropertyName("author")]
    public string Author { get; set; }
}


public class MoonPhaseDto
{
    [JsonPropertyName("Error")]
    public int Error { get; set; }
    [JsonPropertyName("ErrorMsg")]
    public string ErrorMsg { get; set; }
    [JsonPropertyName("TargetDate")]
    public string TargetDate { get; set; }
    [JsonPropertyName("Moon")]
    public List<string> Moon { get; set; }
    [JsonPropertyName("Index")]
    public int Index { get; set; }
    [JsonPropertyName("Age")]
    public double Age { get; set; }
    [JsonPropertyName("Phase")]
    public string Phase { get; set; }
    [JsonPropertyName("Distance")]
    public double Distance { get; set; }
    [JsonPropertyName("Illumination")]
    public double Illumination { get; set; }
    [JsonPropertyName("AngularDiameter")]
    public double AngularDiameter { get; set; }
    [JsonPropertyName("DistanceToSun")]
    public double DistanceToSun { get; set; }
    [JsonPropertyName("SunAngularDiameter")]
    public double SunAngularDiameter { get; set; }
}

public class HoroscopeDto
{
    [JsonPropertyName("sign")]
    public string Sign { get; set; }
    [JsonPropertyName("horoscope")]
    public string Horoscope { get; set; }
}

public class NasaApodDto
{
    public string date { get; set; }
    public string explanation { get; set; }
    public string url { get; set; }
    public string title { get; set; }
    public string media_type { get; set; }
}