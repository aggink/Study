using System.Text.Json.Serialization;

namespace Study.Lab3.Web.Middlewares.DtoModels;

public sealed record ErrorResponseDto
{
    /// <summary>
    /// Код ошибки
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; init; }

    /// <summary>
    /// Сообщение
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; }
}
