namespace Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;

public sealed record SweetDto
{
    /// <summary>
    /// Идентификатор сладости
    /// </summary>
    public Guid ID { get; init; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Идентификатор типа сладости
    /// </summary>
    public Guid SweetTypeID { get; init; }

    /// <summary>
    /// Ингредиент
    /// </summary>
    public string Ingredients { get; init; }
}