using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.Selestz.Models;

public sealed record PostDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; }

    [JsonPropertyName("body")]
    public string Body { get; init; }
}