namespace Study.Lab3.Web.Features.Restaurants.MenuItems.DtoModels;

public sealed record MenuItemDto
{
    /// <summary>
    /// Идентификатор позиции меню
    /// </summary>
    public Guid IsnMenuItem { get; init; }

    /// <summary>
    /// Идентификатор меню
    /// </summary>
    public Guid IsnMenu { get; init; }

    /// <summary>
    /// Название блюда
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Описание блюда
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; init; }

    /// <summary>
    /// Категория блюда
    /// </summary>
    public string Category { get; init; }

    /// <summary>
    /// Доступность блюда
    /// </summary>
    public bool IsAvailable { get; init; }

    /// <summary>
    /// Время приготовления в минутах
    /// </summary>
    public int CookingTimeMinutes { get; init; }
}
