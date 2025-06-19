using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Storage.Models.GameStore;

/// <summary>
/// Игровая платформа
/// </summary>
public class Platform
{
    /// <summary>
    /// Идентификатор платформы
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnPlatform { get; set; }

    /// <summary>
    /// Название платформы
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Platform.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Производитель
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Platform.Manufacturer)]
    public string Manufacturer { get; set; }

    /// <summary>
    /// Тип платформы (Console, PC, Mobile, etc.)
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Platform.Type)]
    public string Type { get; set; }

    /// <summary>
    /// Дата выхода платформы
    /// </summary>
    public DateTime? ReleaseDate { get; set; }

    /// <summary>
    /// Активна ли платформа
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Описание платформы
    /// </summary>
    [MaxLength(ModelConstants.Platform.Description)]
    public string Description { get; set; }

    /// <summary>
    /// Поколение платформы
    /// </summary>
    [Range(ModelConstants.Platform.MinGeneration, ModelConstants.Platform.MaxGeneration)]
    public int? Generation { get; set; }

    /// <summary>
    /// Поддерживает ли онлайн игры
    /// </summary>
    public bool SupportsOnlineGaming { get; set; } = false;
}