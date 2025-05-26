using Study.Lab3.Storage.Enums.University;

namespace Study.Lab3.Web.Features.Library.Authors.DtoModels;

public sealed record AuthorDto
{
    /// <summary>
    /// Идентификатор автора
    /// </summary>
    public Guid IsnAuthor { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string SurName { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string PatronymicName { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public SexType Sex { get; set; }

    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid IsnTeacher { get; set; }
}
