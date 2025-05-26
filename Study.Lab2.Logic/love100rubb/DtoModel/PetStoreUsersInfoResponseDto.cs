using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.love100rubb.DtoModel;

public sealed record PetStoreUsersInfoResponseDto
{
    public class Root
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("username")]
        public string Username { get; init; }

        [JsonPropertyName("firstname")]
        public string FirstName { get; init; }

        [JsonPropertyName("lastname")]
        public string LastName { get; init; }

        [JsonPropertyName("email")]
        public string Email { get; init; }

        [JsonPropertyName("password")]
        public string Password { get; init; }

        [JsonPropertyName("phone")]
        public string Phone { get; init; }

        [JsonPropertyName("userStatus")]
        public int UserStatus { get; init; }
    }
}

