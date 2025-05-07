using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.kinkiss1.DtoModels
{
    public class CatFactTranslatedResponseDto
    {
        [JsonPropertyName("fact")]
        public string Fact { get; init; }

        [JsonPropertyName("length")]
        public int Length { get; init; }

        [JsonPropertyName("перевод")]
        public string Translate { get; init; }
    }
}