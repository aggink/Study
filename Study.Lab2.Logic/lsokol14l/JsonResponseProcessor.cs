using System.Text.Json;
using Study.Lab2.Logic.Interfaces.lsokol14l;

namespace Study.Lab2.Logic.lsokol14l;

public class JsonResponseProcessor : IJsonResponseProcessor
{
    /// <summary>
    /// Обрабатывает JSON-ответ и преобразует его в объект указанного типа.
    /// </summary>
    /// <typeparam name="T">Тип объекта, в который нужно преобразовать ответ.</typeparam>
    /// <param name="response">JSON-ответ в виде строки.</param>
    /// <returns>Объект типа <typeparamref name="T"/>.</returns>
    public T ProcessResponse<T>(string response)
    {
        try
        {
            // Попытка десериализации JSON в объект типа T
            var jsonObject = JsonSerializer.Deserialize<T>(response);
            return jsonObject ?? throw new Exception("Ответ пуст или некорректен.");
        }
        catch (JsonException ex)
        {
            throw new Exception("Ошибка при обработке JSON-ответа", ex);
        }
    }
}

