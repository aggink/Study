namespace Study.Lab3.Web.Features.University.CyberSport.DtoModels;

public sealed record CyberSportWithDetailsDto
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
    /// ФИО студента
    /// </summary>
    public string StudentFullName { get; init; }

    /// <summary>
    /// Идентификатор комп.игры
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Название соревнований
    /// </summary>
    public string SubjectName { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    public int PointsCount { get; init; }

    /// <summary>
    /// Дата проведения соревнований
    /// </summary>
    public DateTime CyberSportDate { get; init; }
}