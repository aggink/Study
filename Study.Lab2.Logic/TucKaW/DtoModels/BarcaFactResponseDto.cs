using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.TucKaW.DtoModels
{
    /// <summary>
    /// Основной DTO для хранения данных о ФК Барселона
    /// </summary>
    public class BarcaFactResponseDto
    {
        [JsonPropertyName("data")]
        public List<string> Data { get; set; } = new List<string>();
    }

    /// <summary>
    /// Вспомогательный класс с методами для работы с BarcaFactResponseDto
    /// </summary>
    public static class BarcaFactResponseHelper
    {
        /// <summary>
        /// Создаёт DTO с набором данных по умолчанию
        /// </summary>
        public static BarcaFactResponseDto CreateDefault()
        {
            return new BarcaFactResponseDto
            {
                Data = new List<string>
                {
                    "ФК Барселона основана 29 ноября 1899 года",
                    "Камп Ноу - домашний стадион (вместимость 99 354)",
                    "Легендарные игроки: Месси, Кройф, Марадона",
                    "Текущий тренер: Хави Эрнандес",
                    "26-кратный чемпион Испании"
                }
            };
        }

        /// <summary>
        /// Возвращает JSON-представление данных по умолчанию
        /// </summary>
        public static string GetDefaultJson()
        {
            return JsonSerializer.Serialize(CreateDefault());
        }
    }
}