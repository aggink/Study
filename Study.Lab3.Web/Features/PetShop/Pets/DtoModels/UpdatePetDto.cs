using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.PetShop;

namespace Study.Lab3.Web.Features.PetShop.Pets.DtoModels;

/// <summary>
/// DTO для обновления животного
/// </summary>
public sealed record UpdatePetDto
{
    /// <summary>
    /// Идентификатор животного
    /// </summary>
    [Required]
    public Guid IsnPet { get; init; }

    /// <summary>
    /// Кличка животного
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Pet.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Порода
    /// </summary>
    [MaxLength(ModelConstants.Pet.Breed)]
    public string Breed { get; init; }

    /// <summary>
    /// Возраст в месяцах
    /// </summary>
    [Range(ModelConstants.Pet.AgeMin, ModelConstants.Pet.AgeMax)]
    public int AgeInMonths { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    [Range(ModelConstants.Pet.PriceMin, ModelConstants.Pet.PriceMax)]
    public double Price { get; init; }

    /// <summary>
    /// Описание
    /// </summary>
    [MaxLength(ModelConstants.Pet.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Статус животного
    /// </summary>
    [Required]
    public PetStatus Status { get; init; }
}