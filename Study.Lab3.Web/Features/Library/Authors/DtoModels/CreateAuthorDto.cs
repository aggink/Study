using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.University;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Library.Authors.DtoModels;

public sealed record CreateAuthorDto
{
    /// <summary>
    /// Фамилия
    /// </summary>
    [Required, MaxLength(ModelConstants.Author.SurName)]
    public string SurName { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required, MaxLength(ModelConstants.Author.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Отчество
    /// </summary>
    [Required, MaxLength(ModelConstants.Author.PatronymicName)]
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
