<<<<<<< HEAD
namespace Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;
=======
namespace Study.Lab3.Web.Features.Sweets.SweetFactory.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

public sealed record SweetFactoryDto
{
    /// <summary>
    /// Идентификатор фабрики
    /// </summary>
    public Guid IsnSweetFactory { get; init; }
<<<<<<< HEAD
    
=======

>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; init; }

    /// <summary>
    /// Объём продукции
    /// </summary>
<<<<<<< HEAD
    public Int64 Volume { get; init; }
=======
    public long Volume { get; init; }
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
}