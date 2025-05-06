using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.kinkiss1.DtoModels
{
    public class GoogleTranslateResponse
    {
        [JsonIgnore]
        private readonly string _rawResponse;

        // Google API возвращает массив массивов
        // Содержащий текст перевода в первом элементе: [0][0][0]
        private List<List<List<string>>> _translations;

        // Конструктор для ручного парсинга, если десериализация не сработает
        public GoogleTranslateResponse(string jsonResponse)
        {
            _rawResponse = jsonResponse;
        }

        [JsonConstructor]
        public GoogleTranslateResponse(List<List<List<string>>> translations)
        {
            _translations = translations;
        }

        [JsonIgnore]
        public string TranslatedText
        {
            get
            {
                // Если есть десериализованные данные - используем их
                if (_translations != null &&
                    _translations.Count > 0 &&
                    _translations[0].Count > 0 &&
                    _translations[0][0].Count > 0)
                {
                    return _translations[0][0][0];
                }

                // Иначе пробуем извлечь вручную через JsonDocument
                if (!string.IsNullOrEmpty(_rawResponse))
                {
                    try
                    {
                        var doc = System.Text.Json.JsonDocument.Parse(_rawResponse);
                        return doc.RootElement[0][0][0].GetString();
                    }
                    catch
                    {
                        return "Не удалось извлечь перевод";
                    }
                }

                return null;
            }
        }
    }
}
