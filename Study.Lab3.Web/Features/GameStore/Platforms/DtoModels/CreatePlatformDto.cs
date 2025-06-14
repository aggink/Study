using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.GameStore.Platforms.DtoModels;

/// <summary>
/// DTO для создания платформы
/// </summary>
public sealed record CreatePlatformDto
{
    /// <summary>
    /// Название платформы
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Platform.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Производитель
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Platform.Manufacturer)]
    public string Manufacturer { get; init; }

    /// <summary>
    /// Тип платформы (Console, PC, Mobile, etc.)
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Platform.Type)]
    public string Type { get; init; }

    /// <summary>
    /// Дата выхода платформы
    /// </summary>
    public DateTime? ReleaseDate { get; init; }

    /// <summary>
    /// Активна ли платформа
    /// </summary>
    public bool IsActive { get; init; } = true;

    /// <summary>
    /// Описание платформы
    /// </summary>
    [MaxLength(ModelConstants.Platform.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Поколение платформы
    /// </summary>
    [Range(ModelConstants.Platform.MinGeneration, ModelConstants.Platform.MaxGeneration)]
    public int? Generation { get; init; }

    /// <summary>
    /// Поддерживает ли онлайн игры
    /// </summary>
    public bool SupportsOnlineGaming { get; init; } = false;
}