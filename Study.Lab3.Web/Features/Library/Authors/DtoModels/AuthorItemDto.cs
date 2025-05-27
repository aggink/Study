using Study.Lab3.Storage.Enums.University;

namespace Study.Lab3.Web.Features.Library.Authors.DtoModels;

public class AuthorItemDto
{
    /// <summary>
    /// Идентификатор автора
    /// </summary>
    public Guid IsnAuthor { get; init; }

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
    /// Идентификатор преподавателя
    /// </summary>
    public Guid? IsnTeacher { get; init; }
}
