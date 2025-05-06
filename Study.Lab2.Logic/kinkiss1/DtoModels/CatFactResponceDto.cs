using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.kinkiss1.DtoModels
{
    public class CatFactResponseDto
    {
        [JsonPropertyName("fact")]
        public string Fact { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }
    }
}
