using System.Text.Json;
using Study.Lab2.Logic.Interfaces.kinkiss1;

namespace Study.Lab2.Logic.kinkiss1;

public class ResponseProcessor : IResponseProcessor
{
    public string FormatJson(string rawJson)
    {
        var jsonElement = JsonSerializer.Deserialize<object>(rawJson);
        return JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}