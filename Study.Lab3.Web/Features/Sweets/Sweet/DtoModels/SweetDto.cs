namespace Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;

public sealed record SweetDto
{
    /// <summary>
    /// Идентификатор сладости
    /// </summary>
    public Int64 ID { get; init; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Идентификатор типа сладости
    /// </summary>
    public Int64 SweetTypeID { get; init; }

    /// <summary>
    /// Ингредиент
    /// </summary>
    public string Ingredients { get; init; }
}