using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.baldfromazzers.DtoModels;

public sealed record UserDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }
    
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    [JsonPropertyName("username")]
    public string Username { get; init; }
    
    [JsonPropertyName("email")]
    public string Email { get; init; }

}