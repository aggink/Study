/*using System.ComponentModel.DataAnnotations;
using Study.Lab3.Storage.Constants;

namespace Study.Lab3.Web.Features.University.Materials.DtoModels;

public sealed record CreateMaterialDto
{
    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [Required]
    public Guid IsnSubject { get; init; }

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

    /// <summary>
    /// Дата публикации
    /// </summary>
    public DateTime PublishDate { get; init; } = DateTime.UtcNow;
}*/