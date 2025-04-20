using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Subjects.DtoModels;

public sealed record CreateSubjectDto
{
    /// <summary>
    /// Название предмета
    /// </summary>
    [Required, MaxLength(ModelConstants.Subject.Name)]
    public string Name { get; init; }
}
