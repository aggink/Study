namespace Study.Lab3.Web.Features.University.Pingpongclub.DtoModels;

public sealed record PingpongclubWithDetailsDto
{
    /// <summary>
    /// Идентификатор спортивного клуба
    /// </summary>
    public Guid IsnPingpongclub { get; init; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// ФИО студента
    /// </summary>
    public string StudentFullName { get; init; }

    /// <summary>
    /// Идентификатор соревнований
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Название соревнований
    /// </summary>
    public string SubjectName { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// Дата проведения соревнований
    /// </summary>
    public DateTime PingpongclubDate { get; init; }
}