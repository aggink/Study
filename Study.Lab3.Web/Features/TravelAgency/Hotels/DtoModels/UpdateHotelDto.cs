using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.TravelAgency;

namespace Study.Lab3.Web.Features.TravelAgency.Hotels.DtoModels;

public sealed record UpdateHotelDto
{
    /// <summary>
    /// Идентификатор отеля
    /// </summary>
    [Required]
    public Guid IsnHotel { get; init; }

    /// <summary>
    /// Название отеля
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Hotel.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Описание отеля
    /// </summary>
    [MaxLength(ModelConstants.Hotel.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Адрес отеля
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Hotel.Address)]
    public string Address { get; init; }

    /// <summary>
    /// Страна
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Hotel.Country)]
    public string Country { get; init; }

    /// <summary>
    /// Город
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Hotel.City)]
    public string City { get; init; }

    /// <summary>
    /// Количество звезд
    /// </summary>
    [Required]
    public HotelStarRating StarRating { get; init; }

    /// <summary>
    /// Цена за ночь
    /// </summary>
    [Required]
    [Range(ModelConstants.Hotel.PricePerNightMin, ModelConstants.Hotel.PricePerNightMax)]
    public decimal PricePerNight { get; init; }

    /// <summary>
    /// Есть ли Wi-Fi
    /// </summary>
    public bool HasWiFi { get; init; }

    /// <summary>
    /// Есть ли бассейн
    /// </summary>
    public bool HasPool { get; init; }

    /// <summary>
    /// Есть ли спа
    /// </summary>
    public bool HasSpa { get; init; }

    /// <summary>
    /// Телефон отеля
    /// </summary>
    [MaxLength(ModelConstants.Hotel.Phone)]
    public string Phone { get; init; }

    /// <summary>
    /// Email отеля
    /// </summary>
    [MaxLength(ModelConstants.Hotel.Email)]
    public string Email { get; init; }
}
