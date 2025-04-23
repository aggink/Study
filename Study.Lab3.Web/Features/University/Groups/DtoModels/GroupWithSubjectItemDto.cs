namespace Study.Lab3.Web.Features.University.Groups.DtoModels;

public class GroupWithSubjectItemDto
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    public Guid IsnGroup { get; init; }

    /// <summary>
    /// Название группы
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Список предметов
    /// </summary>
    public SubjectItemDto[] Subjects { get; init; }
}
