using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyService.DtoModels;

public sealed record UpdateServiceDto
{
    /// <summary>
    /// ID услуги
    /// </summary>
    [Required]
    public Guid IsnService { get; init; }

    /// <summary>
    /// Название услуги
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.BeautyService.ServiceName)]
    public string ServiceName { get; init; }

    /// <summary>
    /// Описание услуги
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.BeautyService.Description)]
    public string Description { get; init; }

    /// <summary>
    /// Цена
    /// </summary>
    [Required]
    [Range(ModelConstants.BeautyService.MinServicePrice, ModelConstants.BeautyService.MaxServicePrice)]
    public int Price { get; set; }

    /// <summary>
    /// Длительность
    /// </summary>
    [Required]
    [MaxLength(ModelConstants.BeautyService.Duration)]
    public int Duration { get; set; }
}