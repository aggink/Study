using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.University;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Authors.DtoModels;

public sealed record UpdateAuthorDto
{
    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required]
    public Guid IsnAuthor { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required, MaxLength(ModelConstants.Author.SurName)]
    public string SurName { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required, MaxLength(ModelConstants.Author.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    [Required, MaxLength(ModelConstants.Author.PatronymicName)]
    public string PatronymicName { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public SexType Sex { get; set; }

    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    [Required, DefaultValue(null)]
    public Guid IsnTeacher { get; set; }
}
