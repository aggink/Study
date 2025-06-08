namespace Study.Lab3.Web.Features.Sweets.Sweet.DtoModels;

public sealed record SweetDto
{
    /// <summary>
    /// Идентификатор сладости
    /// </summary>
    public Guid IsnSweet { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Идентификатор типа сладости
    /// </summary>
    public Guid IsnSweetType { get; init; }

    /// <summary>
    /// Ингредиент
    /// </summary>
    public string Ingredients { get; init; }
}