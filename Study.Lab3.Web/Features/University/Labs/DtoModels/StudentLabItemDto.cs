namespace Study.Lab3.Web.Features.University.Labs.DtoModels;

public class StudentLabItemDto
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
