using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.yamisakimei.DtoModels;

public sealed record UserResponse
{
    [JsonPropertyName("results")]
    public List<UserData>? Results { get; init; }
}

public sealed record UserData
{
    [JsonPropertyName("name")]
    public UserName? Name { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("location")]
    public UserLocation? Location { get; init; }

    [JsonPropertyName("picture")]
    public UserPicture? Picture { get; init; }
}

public sealed record UserName
{
    [JsonPropertyName("first")]
    public string? First { get; init; }

    [JsonPropertyName("last")]
    public string? Last { get; init; }
}

public sealed record UserLocation
{
    [JsonPropertyName("city")]
    public string? City { get; init; }

    [JsonPropertyName("country")]
    public string? Country { get; init; }
}

public sealed record UserPicture
{
    [JsonPropertyName("large")]
    public string? Large { get; init; }
}