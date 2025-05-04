using System.Text.Json;
using Study.Lab2.Logic.Interfaces.kinkiss1;

namespace Study.Lab2.Logic.kinkiss1;

public class ResponseProcessor : IResponseProcessor
{
    public string FormatJsonAnswers(string jsonAnsw)
    {
        if (string.IsNullOrEmpty(jsonAnsw)) return "Empty answer";

        try
        {
            var jsonElement = JsonDocument.Parse(jsonAnsw).RootElement;
            return JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
        catch (JsonException)
        {
            return $"Invalid JSON format: {jsonAnsw}";
        }
    }

    public bool Error(string response)
    {
        if (string.IsNullOrEmpty(response)) return true;
        try
        {
            var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;

            if (root.TryGetProperty("error", out _) ||
                root.TryGetProperty("errors", out _))
                return true;

            return false;
        }
        catch
        {
            return true;
        }
    }

    public string CocnlusionErrorMessage(string response)
    {
        try
        {
            var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;

            if (root.TryGetProperty("error", out var errorProp))
                return errorProp.ToString();

            if (root.TryGetProperty("errors", out var errorsProp))
                return errorsProp.ToString();

            return "Unknown error";
        }
        catch
        {
            return "Unknown error";
        }
    }
}
