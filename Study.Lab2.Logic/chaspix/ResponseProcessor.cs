using Study.Lab2.Logic.Interfaces.chaspix;
using System.Text.Json;

namespace Study.Lab2.Logic.chaspix;

public class ResponseProcessor : IResponseProcessor
{
    public string FormatJsonResponse(string jsonResponse)
    {
        if (string.IsNullOrWhiteSpace(jsonResponse))
            return "Пустой ответ";

        try
        {
            var jsonElement = JsonDocument.Parse(jsonResponse).RootElement;
            return JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
        catch (JsonException)
        {
            return $"Некорректный JSON: {jsonResponse}";
        }
    }

    public bool HasError(string response)
    {
        if (string.IsNullOrWhiteSpace(response))
            return true;

        try
        {
            var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;

            // Проверяем типичные поля ошибок
            return root.TryGetProperty("error", out _) ||
                   root.TryGetProperty("message", out var msg) && msg.GetString()?.Contains("error", StringComparison.OrdinalIgnoreCase) == true;
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

            // Пытаемся найти сообщение об ошибке
            if (root.TryGetProperty("error", out var errorProp))
            {
                if (errorProp.ValueKind == JsonValueKind.String)
                    return errorProp.GetString() ?? "Неизвестная ошибка";
                else if (errorProp.TryGetProperty("message", out var msgProp))
                    return msgProp.GetString() ?? "Неизвестная ошибка";
            }

            if (root.TryGetProperty("message", out var message))
                return message.GetString() ?? "Неизвестная ошибка";

            return "Сервер вернул ошибку";
        }
        catch
        {
            return "Не удалось обработать ответ об ошибке";
        }
    }
}
