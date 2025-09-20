using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.TravelAgency;

namespace Study.Lab3.Storage.Models.TravelAgency;

/// <summary>
/// Отель
/// </summary>
public class Hotel
{
    /// <summary>
    /// Идентификатор отеля
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnHotel { get; set; }

    /// <summary>
    /// Название отеля
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Hotel.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Описание отеля
    /// </summary>
    [MaxLength(ModelConstants.Hotel.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Адрес отеля
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Hotel.Address)]
    public string Address { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Hotel.Country)]
    public string Country { get; set; }

    /// <summary>
    /// Город
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Hotel.City)]
    public string City { get; set; }

    /// <summary>
    /// Количество звезд
    /// </summary>
    [Required]
    public HotelStarRating StarRating { get; set; }

    /// <summary>
    /// Цена за ночь
    /// </summary>
    [Required]
    [Range(ModelConstants.Hotel.PricePerNightMin, ModelConstants.Hotel.PricePerNightMax)]
    public decimal PricePerNight { get; set; }

    /// <summary>
    /// Есть ли Wi-Fi
    /// </summary>
    public bool HasWiFi { get; set; }

    /// <summary>
    /// Есть ли бассейн
    /// </summary>
    public bool HasPool { get; set; }

    /// <summary>
    /// Есть ли спа
    /// </summary>
    public bool HasSpa { get; set; }

    /// <summary>
    /// Телефон отеля
    /// </summary>
    [MaxLength(ModelConstants.Hotel.Phone)]
    public string Phone { get; set; }

    /// <summary>
    /// Email отеля
    /// </summary>
    [MaxLength(ModelConstants.Hotel.Email)]
    public string Email { get; set; }
}
