using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.TucKaW.DtoModels
{
    public class BarcaFactResponseDto
    {
        [JsonPropertyName("data")]
        public List<string> Data { get; set; } = new List<string>();

        public static BarcaFactResponseDto CreateDefault()
        {
            return new BarcaFactResponseDto
            {
                Data = new List<string>
                {
                    "Клуб: ФК Барселона",
                    "Основан: 1899",
                    "Стадион: Камп Ноу",
                    "Тренер: Хави Эрнандес",
                    "Капитан: Серхи Роберто"
                }
            };
        }
    }
}