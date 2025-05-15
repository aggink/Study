using System.Text.Json;
using Study.Lab2.Logic.Interfaces.lsokol14l;

namespace Study.Lab2.Logic.lsokol14l
{
    public class ValidationResponseProcessor : IValidationResponseProcessor
    {
        /// <summary>
        /// Обрабатывает ответ и преобразует его в объект указанного типа.
        /// Проверяет наличие обязательного поля "requiredField".
        /// </summary>
        /// <typeparam name="T">Тип объекта, в который нужно преобразовать ответ.</typeparam>
        /// <param name="response">Ответ в виде строки.</param>
        /// <returns>Объект типа <typeparamref name="T"/>.</returns>
        public T ProcessResponse<T>(string response)
        {
            try
            {
                // Десериализация JSON в объект указанного типа
                var jsonObject = JsonSerializer.Deserialize<T>(response);
                if (jsonObject == null)
                {
                    throw new Exception("Ответ пуст или некорректен.");
                }

                // Проверка на наличие обязательного поля "requiredField"
                if (jsonObject is Dictionary<string, object> dictionary && !dictionary.ContainsKey("requiredField"))
                {
                    throw new Exception("Ответ не содержит обязательного поля 'requiredField'.");
                }

                return jsonObject;
            }
            catch (JsonException ex)
            {
                throw new Exception("Ошибка при валидации JSON-ответа: ", ex);
            }
        }
    }
}
