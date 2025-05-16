using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.University;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Teachers.DtoModels;

public sealed record CreateTeacherDto
{
    /// <summary>
    /// Фамилия
    /// </summary>
    [Required, MaxLength(ModelConstants.Teacher.SurName)]
    public string SurName { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required, MaxLength(ModelConstants.Teacher.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Отчество
    /// </summary>
    [Required, MaxLength(ModelConstants.Teacher.PatronymicName)]
    public string PatronymicName { get; init; }

    /// <summary>
    /// Пол
    /// </summary>
    [Required]
    public SexType Sex { get; init; }
}