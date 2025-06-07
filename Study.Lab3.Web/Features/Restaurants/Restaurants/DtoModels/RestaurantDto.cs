namespace Study.Lab3.Web.Features.Restaurants.Restaurants.DtoModels;

public sealed record RestaurantDto
{
    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    public Guid IsnRestaurant { get; init; }

    /// <summary>
    /// Название ресторана
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; init; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; init; }

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// Время работы
    /// </summary>
    public string WorkingHours { get; init; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedDate { get; init; }
}
