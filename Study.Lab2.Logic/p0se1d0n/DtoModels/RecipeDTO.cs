using System.Text.Json.Serialization;

namespace Study.Lab2.Logic.p0se1d0n.DtoModels;

/// <summary>
/// DTO для представления рецепта
/// </summary>
public sealed record RecipeDto
{
    /// <summary>
    /// Название рецепта
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Список ингредиентов
    /// </summary>
    [JsonPropertyName("ingredients")]
    public IReadOnlyList<string> Ingredients { get; init; } = new List<string>();

    /// <summary>
    /// Шаги приготовления
    /// </summary>
    [JsonPropertyName("instructions")]
    public IReadOnlyList<string> Instructions { get; init; } = new List<string>();

    /// <summary>
    /// Время подготовки в минутах
    /// </summary>
    [JsonPropertyName("prepTimeMinutes")]
    public int PrepTimeMinutes { get; init; }

    /// <summary>
    /// Время готовки в минутах
    /// </summary>
    [JsonPropertyName("cookTimeMinutes")]
    public double CookTimeMinutes { get; init; }

    /// <summary>
    /// Сложность рецепта (по шкале от 1 до 5)
    /// </summary>
    [JsonPropertyName("difficulty")]
    public string Difficulty { get; init; } = String.Empty;
}