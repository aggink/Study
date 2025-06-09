using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Labs.DtoModels;

public sealed record CreateStudentLabDto
{
    /// <summary>
    /// Наименование группы
    /// </summary>
    [Required]
    public Guid IsnStudent { get; init; }
    [Required]
    public Guid IsnLab { get; init; }
    [Required]
    public int Value { get; init; }
}
