using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.baldfromazzers.DtoModels;

public class CommentDto
{
    [JsonPropertyName("postId")]
    public int PostId { get; set; }
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("body")]
    public string Body { get; set; }

}