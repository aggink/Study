using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.baldfromazzers.DtoModels;

sealed record CommentDto
{
    [JsonPropertyName("postId")]
    public int PostId { get; init; }
    
    [JsonPropertyName("id")]
    public int Id { get; init; }
    
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    [JsonPropertyName("email")]
    public string Email { get; init; }
    
    [JsonPropertyName("body")]
    public string Body { get; init; }

}
//==