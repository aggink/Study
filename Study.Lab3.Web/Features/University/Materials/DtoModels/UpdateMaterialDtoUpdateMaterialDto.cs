/*using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.University.Materials.DtoModels;

public sealed record UpdateMaterialDto
{
    /// <summary>
    /// Идентификатор материала
    /// </summary>
    [Required]
    public Guid IsnMaterial { get; init; }

    /// <summary>
    /// Название материала
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Material.Title)]
    public string Title { get; init; }

    /// <summary>
    /// Описание материала
    /// </summary>
    [MaxLength(ModelConstants.Material.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Тип материала
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Material.Type)]
    public string Type { get; init; }

    /// <summary>
    /// URL материала
    /// </summary>
    [Required]
    public string Url { get; init; }
}*/