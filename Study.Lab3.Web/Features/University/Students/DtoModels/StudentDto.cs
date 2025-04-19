using Study.Lab3.Storage.Enums.University;

namespace Study.Lab3.Web.Features.University.Students.DtoModels;

public sealed record StudentDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Идентификатор группы
    /// </summary>
    public Guid IsnGroup { get; init; }

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

    /// <summary>
    /// Возраст
    /// </summary>
    public int Age { get; init; }
}
