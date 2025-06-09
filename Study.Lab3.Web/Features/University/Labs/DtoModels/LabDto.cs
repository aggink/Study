namespace Study.Lab3.Web.Features.University.Labs.DtoModels;

public sealed record LabDto
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    public Guid IsnLab { get; init; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; init; }
}
