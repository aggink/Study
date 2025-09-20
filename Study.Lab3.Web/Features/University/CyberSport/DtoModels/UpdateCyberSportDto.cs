using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.CyberSport.DtoModels;

public sealed record UpdateCyberSportDto
{
    /// <summary>
    /// Идентификатор киберспорта
    /// </summary>
    [Required]
    public Guid IsnCyberSport { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    [Required]
    [Range(ModelConstants.CyberSport.MinPointsValue, ModelConstants.CyberSport.MaxPointsValue)]
    public int PointsCount { get; init; }

    /// <summary>
    /// Дата проведения соревнований
    /// </summary>
    [Required]
    public DateTime CyberSportDate { get; init; }
}