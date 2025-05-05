using System.Text.Json;
using Study.Lab2.Logic.Interfaces.Selestz;

namespace Study.Lab2.Logic.Selestz;

public class ResponseProcessor : IResponseProcessor
{
    public T FormatJsonResponse<T>(string jsonResponse) where T : class
    {
        if (string.IsNullOrWhiteSpace(jsonResponse))
            throw new ArgumentException("Empty response", nameof(jsonResponse));

        if (HasError(jsonResponse))
            throw new Exception(ExtractErrorMessage(jsonResponse));

        try
        {
            return JsonSerializer.Deserialize<T>(jsonResponse)
                   ?? throw new Exception("Deserialization returned null");
        }
        catch (JsonException ex)
        {
            throw new Exception("Invalid JSON format", ex);
        }
    }

    public bool HasError(string response)
    {
        if (string.IsNullOrWhiteSpace(response))
            return true;

        try
        {
            using var doc = JsonDocument.Parse(response);
            return doc.RootElement.TryGetProperty("error", out _);
        }
        catch
        {
            return true;
        }
    }

    public string ExtractErrorMessage(string response)
    {
        if (string.IsNullOrWhiteSpace(response))
            return "Empty response";

        try
        {
            using var doc = JsonDocument.Parse(response);
            if (doc.RootElement.TryGetProperty("error", out var errorProp))
            {
                return errorProp.GetString() ?? "Unknown error";
            }
            return "Server returned an error";
        }
        catch (JsonException ex)
        {
            return $"Failed to parse error response: {ex.Message}";
        }
    }
}