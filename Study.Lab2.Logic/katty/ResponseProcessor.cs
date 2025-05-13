using Study.Lab2.Logic.Interfaces.katty;
using System.Text.Json;

namespace Study.Lab2.Logic.katty;

public class ResponseProcessor : IResponseProcessor
{
    private readonly JsonSerializerOptions _option = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public bool IsSuccessResponse<T>(string response)
    {
        if (string.IsNullOrWhiteSpace(response) || response.StartsWith("Error:"))
        {
            return false;
        }

        try
        {
            JsonSerializer.Deserialize<T>(response, _option);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public string ProcessResponse<T>(string response)
    {
        if (string.IsNullOrWhiteSpace(response) || response.StartsWith("Error:"))
        {
            return response;
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<T>(response, _option);
            return JsonSerializer.Serialize(deserialized, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            });
        }
        catch (Exception ex)
        {
            return $"Error: Неверный формат JSON - {ex.Message}";
        }
    }
}