namespace Study.Lab3.Web.Features.University.Labs.DtoModels;

public sealed record StudentLabDto
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    public Guid IsnLab { get; init; }

    /// <summary>
    /// Идентификатор группы
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Идентификатор группы
    /// </summary>
    public Guid IsnStudentLab { get; init; }

    /// <summary>
    /// Название
    /// </summary>
    public int Value { get; init; }
}
