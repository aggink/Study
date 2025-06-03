using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.MenuItems.DtoModels;

public sealed record UpdateMenuItemDto
{
    /// <summary>
    /// Идентификатор позиции меню
    /// </summary>
    [Required]
    public Guid IsnMenuItem { get; init; }

    /// <summary>
    /// Название блюда
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MenuItem.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Описание блюда
    /// </summary>
    [MaxLength(ModelConstants.MenuItem.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    [Required]
    [Range(ModelConstants.MenuItem.MinPrice, ModelConstants.MenuItem.MaxPrice)]
    public double Price { get; set; }

    /// <summary>
    /// Категория блюда
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MenuItem.Category)]
    public string Category { get; init; }

    /// <summary>
    /// Доступность блюда
    /// </summary>
    public bool IsAvailable { get; init; }

    /// <summary>
    /// Время приготовления в минутах
    /// </summary>
    [Range(ModelConstants.MenuItem.MinCookingTime, ModelConstants.MenuItem.MaxCookingTime)]
    public int CookingTimeMinutes { get; init; }
}