using Study.Lab2.Logic.Interfaces.katty;
using System.Text.Json;

namespace Study.Lab2.Logic.katty;

public class ResponseProcessor : IResponseProcessor
{
    public bool IsSuccessResponse(string response)
    {
        if (response.StartsWith("Error:"))
        {
            return false;
        }

        try
        {
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(response);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public string ProcessResponse(string response)
    {
        if (response.StartsWith("Error:"))
        {
            return response;
        }

        try
        {
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(response);
            return JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
        catch (Exception ex)
        {
            return $"Error: Неверный формат JSON - {ex.Message}";
        }
    }
}