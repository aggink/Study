namespace Study.Lab3.Web.Features.University.ProjectActivities.DtoModels;

public sealed record ProjectActivitiesWithDetailsDto
{
    /// <summary>
    /// Идентификатор проектной деятельности
    /// </summary>
    public Guid IsnProjectActivities { get; init; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// ФИО студента
    /// </summary>
    public string StudentFullName { get; init; }

    /// <summary>
    /// Идентификатор темы выступления
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Название темы выступления
    /// </summary>
    public string SubjectName { get; init; }

    /// <summary>
    /// Значение количества выступлений
    /// </summary>
    public int PerformancesCount { get; init; }

    /// <summary>
    /// Дата проведения выступлений
    /// </summary>
    public DateTime ProjectActivitiesDate { get; init; }
}