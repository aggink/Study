using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.TucKaW.DtoModels
{
    public class BarcaFactResponseDto
    {
        [JsonPropertyName("data")]
        public List<string> Data { get; set; } = new List<string>();
    }
}