namespace Study.Lab3.Web.Features.University.Groups.DtoModels;

public sealed record SubjectItemDto
{
    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    public Guid IsnSubject { get; set; }

    /// <summary>
    /// Название предмета
    /// </summary>
    public string Name { get; set; }
}
