using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.GameStore;

/// <summary>
/// Разработчик игр
/// </summary>
public class Developer
{
    /// <summary>
    /// Идентификатор разработчика
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnDeveloper { get; set; }

    /// <summary>
    /// Название компании разработчика
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Developer.CompanyName)]
    public string CompanyName { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Developer.Country)]
    public string Country { get; set; }

    /// <summary>
    /// Дата основания компании
    /// </summary>
    public DateTime? FoundedDate { get; set; }

    /// <summary>
    /// Веб-сайт
    /// </summary>
    [MaxLength(ModelConstants.Developer.Website)]
    public string Website { get; set; }

    /// <summary>
    /// Email для связи
    /// </summary>
    [MaxLength(ModelConstants.Developer.ContactEmail)]
    [EmailAddress]
    public string ContactEmail { get; set; }

    /// <summary>
    /// Активен ли разработчик
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Описание компании
    /// </summary>
    [MaxLength(ModelConstants.Developer.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Игры этого разработчика
    /// </summary>
    [InverseProperty(nameof(Game.Developer))]
    public virtual ICollection<Game> Games { get; set; }
}