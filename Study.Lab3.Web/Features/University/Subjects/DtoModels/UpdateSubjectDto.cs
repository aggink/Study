using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Subjects.DtoModels;

public sealed record UpdateSubjectDto
{
    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [Required]
    public Guid IsnSubject { get; set; }

    /// <summary>
    /// Название предмета
    /// </summary>
    [Required, MaxLength(ModelConstants.Subject.Name)]
    public string Name { get; set; }
}
