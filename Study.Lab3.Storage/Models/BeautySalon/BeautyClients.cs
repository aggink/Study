using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Storage.Models.BeautySalon;

/// <summary>
/// Клиент салона красоты
/// </summary>
public class BeautyClients
{
    /// <summary>
    /// ID клиента
    /// </summary>
    [Required, MaxLength(ModelConstants.BeautyClient.ClientID)]
    public string ClientID { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required, MaxLength(ModelConstants.BeautyClient.FirstName)]
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required, MaxLength(ModelConstants.BeautyClient.LastName)]
    public string LastName { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [Required, MaxLength(ModelConstants.BeautyClient.PhoneNumber)]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    [Required, MaxLength(ModelConstants.BeautyClient.EmailAddress)]
    public string EmailAddress { get; set; }
}
