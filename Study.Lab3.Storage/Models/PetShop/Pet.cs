using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.PetShop;

namespace Study.Lab3.Storage.Models.PetShop;

/// <summary>
/// Животное в зоомагазине
/// </summary>
public class Pet
{
    /// <summary>
    /// Идентификатор животного
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPet { get; set; }

    /// <summary>
    /// Кличка животного
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Pet.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Вид животного
    /// </summary>
    [Required]
    public PetSpecies Species { get; set; }

    /// <summary>
    /// Порода
    /// </summary>
    [MaxLength(ModelConstants.Pet.Breed)]
    public string Breed { get; set; }

    /// <summary>
    /// Возраст в месяцах
    /// </summary>
    [Range(ModelConstants.Pet.AgeMin, ModelConstants.Pet.AgeMax)]
    public int AgeInMonths { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    [Range(ModelConstants.Pet.PriceMin, ModelConstants.Pet.PriceMax)]
    public double Price { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    [MaxLength(ModelConstants.Pet.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Дата поступления в магазин
    /// </summary>
    [Required]
    public DateTime ArrivalDate { get; set; }

    /// <summary>
    /// Статус животного
    /// </summary>
    [Required]
    public PetStatus Status { get; set; }
}