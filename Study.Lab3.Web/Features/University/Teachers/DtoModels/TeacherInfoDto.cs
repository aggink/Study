namespace Study.Lab3.Web.Features.University.Teachers.DtoModels;

public sealed record TeacherInfoDto
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    public Guid IsnTeacher { get; init; }

    /// <summary>
    /// ФИО учителя
    /// </summary>
    public string FullName { get; init; }
}