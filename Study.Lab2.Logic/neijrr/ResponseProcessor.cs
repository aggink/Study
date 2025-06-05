using System.Text.Json;
using Study.Lab2.Logic.Interfaces.neijrr;

namespace Study.Lab2.Logic.neijrr;

public class ResponseProcessor : IResponseProcessor
{
    private readonly static JsonSerializerOptions _prettySerializerOptions = new()
    {
        WriteIndented = true
    };

    public string ToJsonString(object obj, bool pretty = false)
    {
        try
        {
            if (obj.GetType() == typeof(string))
                obj = JsonDocument.Parse(obj as string);

            return JsonSerializer.Serialize(obj, pretty ? _prettySerializerOptions : JsonSerializerOptions.Default);
        }
        catch (JsonException ex)
        {
            throw new ArgumentException("Ошибка сериализации объекта", nameof(obj), ex);
        }
    }

    public JsonDocument ToJsonDocument(object obj)
    {
        try
        {
            return JsonDocument.Parse(obj.ToString());
        }
        catch (JsonException)
        {
            return null;
        }
    }

    public string GetErrorMessage(string response)
    {
        if (string.IsNullOrWhiteSpace(response)) return "Пустой ответ";

        var json = ToJsonDocument(response);
        return json is null ? "Ошибка при парсинге ответа" : GetErrorMessage(json);
    }

    public string GetErrorMessage(JsonDocument response)
    {
        if (response is null) return "Пустой ответ";

        // Пытаемся найти сообщение об ошибке в различных форматах
        var root = response.RootElement;
        if (root.TryGetProperty("error", out var errorProp))
        {
            if (errorProp.ValueKind == JsonValueKind.String)
                return errorProp.GetString();
            else if (errorProp.TryGetProperty("message", out var msgProp))
                return msgProp.GetString();
        }

        // Если не нашли стандартное поле ошибки, считаем, что ошибки нет
        return null;
    }
}
