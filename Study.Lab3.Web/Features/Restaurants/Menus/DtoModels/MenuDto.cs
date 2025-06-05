namespace Study.Lab3.Web.Features.Restaurants.Menus.DtoModels;

public sealed record MenuDto
{
    /// <summary>
    /// Идентификатор меню
    /// </summary>
    public Guid IsnMenu { get; init; }

    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    public Guid IsnRestaurant { get; init; }

    /// <summary>
    /// Название меню
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Активность меню
    /// </summary>
    public bool IsActive { get; init; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedDate { get; init; }
}
