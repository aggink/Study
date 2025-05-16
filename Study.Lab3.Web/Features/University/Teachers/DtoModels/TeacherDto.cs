using Study.Lab3.Storage.Enums.University;

namespace Study.Lab3.Web.Features.University.Teachers.DtoModels;

public sealed record TeacherDto
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    public Guid IsnTeacher { get; init; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string SurName { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string PatronymicName { get; init; }

    /// <summary>
    /// Пол
    /// </summary>
    public SexType Sex { get; init; }
}