using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Study.Lab2.Logic.Maxtir23.DtoModels;

public sealed record RecipeDTO
{
    public class Root
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("username")]
        public string Username { get; init; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; init; }

        [JsonPropertyName("lastName")]
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
