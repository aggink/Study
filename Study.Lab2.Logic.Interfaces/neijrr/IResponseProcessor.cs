using System.Text.Json;

namespace Study.Lab2.Logic.Interfaces.neijrr;

public interface IResponseProcessor
{
    /// <summary>
    /// Сериализует объект в строку JSON
    /// </summary>
    /// <param name="obj">Сериализуемый объект</param>
    /// <param name="pretty">
    /// Если <see langword="true"/>, JSON
    /// форматируется с пробелами и переносами строк
    /// </param>
    /// <returns>Строка с JSON объектом</returns>
    string ToJsonString(object obj, bool pretty = false);

    /// <summary>
    /// Десериализует объект в JSON
    /// </summary>
    /// <param name="obj">Десериализуемый объект</param>
    /// <returns>Объект JsonDocument, или <see langword="null"/> при ошибке десериализации</returns>
    public JsonDocument ToJsonDocument(object obj);

    /// <summary>
    /// Извлекает сообщение об ошибке из ответа
    /// </summary>
    /// <param name="response">Ответ от сервера</param>
    /// <returns>Текст ошибки, или null при отсутствии ошибок</returns>
    string GetErrorMessage(string response);

    /// <summary>
    /// Извлекает сообщение об ошибке из ответа
    /// </summary>
    /// <param name="response">Ответ от сервера</param>
    /// <returns>Текст ошибки, или null при отсутствии ошибок</returns>
    string GetErrorMessage(JsonDocument response);
}
