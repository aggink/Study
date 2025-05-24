using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.Cherryy.DtoModels;

public sealed record UserDto
{
    [JsonPropertyName("login")]
    public string Login { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; }

    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; init; }

    [JsonPropertyName("gravatar_id")]
    public string GravatarId { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; }

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; }

    [JsonPropertyName("followers_url")]
    public string FollowersUrl { get; init; }

    [JsonPropertyName("following_url")]
    public string FollowingUrl { get; init; }

    [JsonPropertyName("gists_url")]
    public string GistsUrl { get; init; }

    [JsonPropertyName("starred_url")]
    public string StarredUrl { get; init; }

    [JsonPropertyName("subscriptions_url")]
    public string SubscriptionsUrl { get; init; }

    [JsonPropertyName("organizations_url")]
    public string OrganizationsUrl { get; init; }

    [JsonPropertyName("repos_url")]
    public string ReposUrl { get; init; }

    [JsonPropertyName("events_url")]
    public string EventsUrl { get; init; }

    [JsonPropertyName("received_events_url")]
    public string ReceivedEventsUrl { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("user_view_type")]
    public string UserViewType { get; init; }

    [JsonPropertyName("site_admin")]
    public bool SiteAdmin { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("company")]
    public string Company { get; init; }

    [JsonPropertyName("blog")]
    public string Blog { get; init; }

    [JsonPropertyName("location")]
    public string Location { get; init; }

    [JsonPropertyName("email")]
    public string Email { get; init; }

    [JsonPropertyName("hireable")]
    public string Hireable { get; init; }

    [JsonPropertyName("bio")]
    public string Bio { get; init; }

    [JsonPropertyName("twitter_username")]
    public string TwitterUsername { get; init; }

    [JsonPropertyName("public_repos")]
    public int PublicRepos { get; init; }

    [JsonPropertyName("public_gists")]
    public int PublicGists { get; init; }

    [JsonPropertyName("followers")]
    public int Followers { get; init; }

    [JsonPropertyName("following")]
    public int Following { get; init; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; init; }
}
