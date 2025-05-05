using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.Selestz.Models;

public sealed record TodoDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; }

    [JsonPropertyName("completed")]
    public bool Completed { get; init; }
}