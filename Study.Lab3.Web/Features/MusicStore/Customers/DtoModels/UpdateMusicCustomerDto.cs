using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.MusicStore;

namespace Study.Lab3.Web.Features.MusicStore.Customers.DtoModels;

public sealed record UpdateMusicCustomerDto
{
    /// <summary>
    /// Идентификатор покупателя
    /// </summary>
    [Required]
    public Guid IsnCustomer { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicCustomer.FirstName)]
    public string FirstName { get; init; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicCustomer.LastName)]
    public string LastName { get; init; }

    /// <summary>
    /// Email адрес
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicCustomer.Email)]
    public string Email { get; init; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [MaxLength(ModelConstants.MusicCustomer.Phone)]
    public string Phone { get; init; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; init; }

    /// <summary>
    /// Предпочитаемый жанр музыки
    /// </summary>
    [MaxLength(ModelConstants.MusicCustomer.PreferredGenre)]
    public string PreferredGenre { get; init; }

    /// <summary>
    /// Статус покупателя
    /// </summary>
    [Required]
    public CustomerStatus Status { get; init; }
}
