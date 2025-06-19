using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.baldfromazzers.DtoModels;

public sealed record PostDto
{
    [JsonPropertyName("userId")]
    public int UserId { get; init; }
    
    [JsonPropertyName("id")]
    public int Id { get; init; }
    
    [JsonPropertyName("title")]
    public string Title { get; init; }
    
    [JsonPropertyName("body")]
    public string Body { get; init; }

}