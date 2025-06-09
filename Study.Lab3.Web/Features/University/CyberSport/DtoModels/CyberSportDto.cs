namespace Study.Lab3.Web.Features.University.CyberSport.DtoModels;

public sealed record CyberSportDto
{
    /// <summary>
    /// Идентификатор киберспорта
    /// </summary>
    public Guid IsnCyberSport { get; init; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Идентификатор комп.игры
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    public int PointsCount { get; init; }

    /// <summary>
    /// Дата проведения соревнований
    /// </summary>
    public DateTime CyberSportDate { get; init; }
}