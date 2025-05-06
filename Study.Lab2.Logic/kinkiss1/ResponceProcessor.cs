using System.Text.Json;
using Study.Lab2.Logic.Interfaces.kinkiss1;

namespace Study.Lab2.Logic.kinkiss1;

public class ResponseProcessor : IResponseProcessor
{
    public string FormatJson<T>(string rawJson) where T : class
    {
        if (string.IsNullOrEmpty(rawJson))
        {
            throw new ArgumentException("Входная JSON строка не может быть пустой", nameof(rawJson));
        }

        try
        {
            var jsonElement = JsonSerializer.Deserialize<T>(rawJson);
            return JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
        catch (JsonException ex)
        {
            throw new JsonException($"Ошибка при форматировании JSON: {ex.Message}", ex);
        }
    }
}