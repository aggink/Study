<<<<<<< HEAD
namespace Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;
=======
namespace Study.Lab3.Web.Features.Sweets.Sweet.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

public sealed record SweetDto
{
    /// <summary>
    /// Идентификатор сладости
    /// </summary>
    public Guid IsnSweet { get; init; }
<<<<<<< HEAD
    
=======

>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
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