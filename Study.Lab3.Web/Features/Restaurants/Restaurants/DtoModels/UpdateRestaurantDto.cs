using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Restaurants.Restaurants.DtoModels;

public sealed record UpdateRestaurantDto
{
    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    [Required]
    public Guid IsnRestaurant { get; init; }

    /// <summary>
    /// Название ресторана
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Restaurant.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Адрес
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Restaurant.Address)]
    public string Address { get; init; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [MaxLength(ModelConstants.Restaurant.Phone)]
    public string Phone { get; init; }

    /// <summary>
    /// Email
    /// </summary>
    [MaxLength(ModelConstants.Restaurant.Email)]
    public string Email { get; init; }

    /// <summary>
    /// Время работы
    /// </summary>
    [MaxLength(ModelConstants.Restaurant.WorkingHours)]
    public string WorkingHours { get; init; }
}