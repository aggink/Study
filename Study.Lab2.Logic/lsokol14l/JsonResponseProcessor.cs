using System.Text.Json;
using Study.Lab2.Logic.Interfaces.lsokol14l;

namespace Study.Lab2.Logic.lsokol14l
{
    public class JsonResponseProcessor : IJsonResponseProcessor
    {
        public object ProcessResponse(string response)
        {
            try
            {
                // Попытка десериализации JSON
                var jsonObject = JsonSerializer.Deserialize<object>(response);
                return jsonObject ?? throw new Exception("Ответ пуст или некорректен.");
            }
            catch (JsonException ex)
            {
                throw new Exception("Ошибка при обработке JSON-ответа: " + ex.Message);
            }
        }
    }
}
