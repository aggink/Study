using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.Taipano.DtoModels
{
    public sealed record PoductFactResponseDto
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("category")]
        public string Category { get; init; }

        [JsonPropertyName("price")]
        public double Price { get; init; }
    }
}
