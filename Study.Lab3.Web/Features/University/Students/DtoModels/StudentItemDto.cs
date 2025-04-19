using Study.Lab3.Storage.Enums.University;

namespace Study.Lab3.Web.Features.University.Students.DtoModels;

public sealed record StudentItemDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Имя группы
    /// </summary>
    public string GroupName { get; init; }

    /// <summary>
    /// Фамилия Имя Отчество
    /// </summary>
    public string Fio { get; init; }

    /// <summary>
    /// Пол
    /// </summary>
    public SexType Sex { get; init; }

    /// <summary>
    /// Возраст
    /// </summary>
    public int Age { get; init; }
}
