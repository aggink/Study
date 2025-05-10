using System.Text.Json;
using Study.Lab2.Logic.Interfaces.lsokol14l;

namespace Study.Lab2.Logic.lsokol14l
{
    public class ValidationResponseProcessor : IValidationResponseProcessor
    {
        public object ProcessResponse(string response)
        {
            try
            {
                var jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
                if (jsonObject == null || !jsonObject.ContainsKey("requiredField"))
                {
                    throw new Exception("Ответ не содержит обязательного поля 'requiredField'.");
                }

                return jsonObject;
            }
            catch (JsonException ex)
            {
                throw new Exception("Ошибка при валидации JSON-ответа: " + ex.Message);
            }
        }
    }
}
