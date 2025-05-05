using System.Text.Json;
using Study.Lab2.Logic.Interfaces.Selestz;

namespace Study.Lab2.Logic.Selestz;

public class ResponseProcessor : IResponseProcessor
{
    public string FormatJsonResponse(string jsonResponse)
    {
        if (string.IsNullOrWhiteSpace(jsonResponse))
            return "Empty response";

        try
        {
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(jsonResponse);
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
        if (string.IsNullOrWhiteSpace(response))
            return true;

        try
        {
            var doc = JsonDocument.Parse(response);
            return doc.RootElement.TryGetProperty("error", out _);
        }
        catch
        {
            return true;
        }
    }

    public string ExtractErrorMessage(string response)
    {
        try
        {
            var doc = JsonDocument.Parse(response);
            if (doc.RootElement.TryGetProperty("error", out var errorProp))
            {
                return errorProp.GetString() ?? "Unknown error";
            }
            return "Server returned an error";
        }
        catch
        {
            return "Failed to parse error response";
        }
    }
}