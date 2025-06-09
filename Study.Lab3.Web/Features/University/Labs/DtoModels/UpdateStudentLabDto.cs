using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Labs.DtoModels;

public sealed record UpdateStudentLabDto
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Required]
    public Guid IsnStudentLab { get; set; }

    /// <summary>
    /// Наименование группы
    /// </summary>
    [Required]
    public int Value { get; set; }
}
