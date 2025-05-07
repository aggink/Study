using System.Text.Json;
using Study.Lab2.Logic.Interfaces.xynthh;

namespace Study.Lab2.Logic.xynthh;

public class ResponseProcessor : IResponseProcessor
{
    public string FormatJsonResponse(string jsonResponse)
    {
        if (string.IsNullOrWhiteSpace(jsonResponse)) return "Empty response";

        try
        {
            // Преобразуем строку JSON в объект для форматирования
            var jsonElement = JsonDocument.Parse(jsonResponse).RootElement;

            // Затем преобразуем обратно с отступами для красивого вывода
            return JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
        catch (JsonException)
        {
            return $"Invalid JSON format: {jsonResponse}";
        }
    }

    public bool HasError(string response)
    {
        if (string.IsNullOrWhiteSpace(response)) return true;

        try
        {
            var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;

            // Проверяем типичные поля ошибок в API
            if (root.TryGetProperty("error", out _) ||
                root.TryGetProperty("errors", out _))
                return true;

            return false;
        }
        catch
        {
            // Если не удалось распарсить JSON, считаем это ошибкой
            return true;
        }
    }

    public string ExtractErrorMessage(string response)
    {
        try
        {
            var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;

            // Пытаемся найти сообщение об ошибке в различных форматах
            if (root.TryGetProperty("error", out var errorProp))
            {
                if (errorProp.ValueKind == JsonValueKind.String)
                    return errorProp.GetString() ?? "Unknown error";
                else if (errorProp.TryGetProperty("message", out var msgProp))
                    return msgProp.GetString() ?? "Unknown error";
            }

            // Если не нашли стандартное поле ошибки, возвращаем общее сообщение
            return "Server returned an error";
        }
        catch
        {
            return "Failed to parse error response";
        }
    }
}