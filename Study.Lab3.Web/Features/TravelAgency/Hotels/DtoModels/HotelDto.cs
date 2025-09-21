using Study.Lab3.Storage.Enums.TravelAgency;

namespace Study.Lab3.Web.Features.TravelAgency.Hotels.DtoModels;

public sealed record HotelDto
{
    /// <summary>
    /// Идентификатор отеля
    /// </summary>
    public Guid IsnHotel { get; init; }

    /// <summary>
    /// Название отеля
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Описание отеля
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Адрес отеля
    /// </summary>
    public string Address { get; init; }

    /// <summary>
    /// Страна
    /// </summary>
    public string Country { get; init; }

    /// <summary>
    /// Город
    /// </summary>
    public string City { get; init; }

    /// <summary>
    /// Количество звезд
    /// </summary>
    public HotelStarRating StarRating { get; init; }

    /// <summary>
    /// Цена за ночь
    /// </summary>
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
    public string Phone { get; init; }

    /// <summary>
    /// Email отеля
    /// </summary>
    public string Email { get; init; }
}
