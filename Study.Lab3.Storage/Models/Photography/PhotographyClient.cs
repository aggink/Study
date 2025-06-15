using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.Photography;

/// <summary>
/// Клиент фотостудии
/// </summary>
public class PhotographyClient
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPhotographyClient { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyClient.FirstName)]
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyClient.LastName)]
    public string LastName { get; set; }

    /// <summary>
    /// Телефон
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyClient.Phone)]
    public string Phone { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.PhotographyClient.Email)]
    public string Email { get; set; }

    /// <summary>
    /// Дата регистрации
    /// </summary>
    [Required]
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// Комментарии о клиенте
    /// </summary>
    [MaxLength(ModelConstants.PhotographyClient.Notes)]
    public string Notes { get; set; }
}