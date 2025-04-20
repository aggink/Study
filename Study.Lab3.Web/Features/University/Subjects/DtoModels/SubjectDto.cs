namespace Study.Lab3.Web.Features.University.Subjects.DtoModels;

public sealed record SubjectDto
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
