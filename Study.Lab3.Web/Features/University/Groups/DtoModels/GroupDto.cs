namespace Study.Lab3.Web.Features.University.Groups.DtoModels;

public sealed record GroupDto
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    public Guid IsnGroup { get; init; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; init; }
}
