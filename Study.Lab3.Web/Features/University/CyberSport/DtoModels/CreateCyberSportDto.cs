using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.CyberSport.DtoModels;

public sealed record CreateCyberSportDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Required]
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Идентификатор комп.игры
    /// </summary>
    [Required]
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    [Required]
    [Range(ModelConstants.CyberSport.MinPointsValue, ModelConstants.CyberSport.MaxPointsValue)]
    public int PointsCount { get; init; }

    /// <summary>
    /// Дата соревнований
    /// </summary>
    [Required]
    public DateTime CyberSportDate { get; init; }
}