using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.MusicStore;

namespace Study.Lab3.Storage.Models.MusicStore;

/// <summary>
/// Покупатель музыкального магазина
/// </summary>
public class MusicCustomer
{
    /// <summary>
    /// Идентификатор покупателя
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnCustomer { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicCustomer.FirstName)]
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicCustomer.LastName)]
    public string LastName { get; set; }

    /// <summary>
    /// Email адрес
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.MusicCustomer.Email)]
    public string Email { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [MaxLength(ModelConstants.MusicCustomer.Phone)]
    public string Phone { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// Предпочитаемый жанр музыки
    /// </summary>
    [MaxLength(ModelConstants.MusicCustomer.PreferredGenre)]
    public string PreferredGenre { get; set; }

    /// <summary>
    /// Статус покупателя
    /// </summary>
    [Required]
    public CustomerStatus Status { get; set; }

    /// <summary>
    /// Дата регистрации
    /// </summary>
    [Required]
    public DateTime RegistrationDate { get; set; }
}