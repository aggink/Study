using Study.Lab3.Storage.Enums.PetShop;

namespace Study.Lab3.Web.Features.PetShop.Pets.DtoModels;

/// <summary>
/// DTO для чтения животного
/// </summary>
public sealed record PetDto
{
    /// <summary>
    /// Идентификатор животного
    /// </summary>
    public Guid IsnPet { get; init; }

    /// <summary>
    /// Кличка животного
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Вид животного
    /// </summary>
    public PetSpecies Species { get; init; }

    /// <summary>
    /// Порода
    /// </summary>
    public string Breed { get; init; }

    /// <summary>
    /// Возраст в месяцах
    /// </summary>
    public int AgeInMonths { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; init; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Дата поступления в магазин
    /// </summary>
    public DateTime ArrivalDate { get; init; }

    /// <summary>
    /// Статус животного
    /// </summary>
    public PetStatus Status { get; init; }
}