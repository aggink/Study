using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.Services.DtoModels;

public sealed record CreateWorkshopServiceDto
{
    /// <summary>
    /// Название услуги
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.Service.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Описание услуги
    /// </summary>
    [MaxLength(ModelConstants.Service.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Цена услуги
    /// </summary>
    [Required]
    [Range(ModelConstants.Service.MinPrice, ModelConstants.Service.MaxPrice)]
    public double Price { get; init; }

    /// <summary>
    /// Длительность выполнения в минутах
    /// </summary>
    [Required]
    [Range(ModelConstants.Service.MinDuration, ModelConstants.Service.MaxDuration)]
    public int Duration { get; init; }
}
