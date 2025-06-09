using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Labs.DtoModels;

public sealed record UpdateLabDto
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Required]
    public Guid IsnLab { get; set; }

    /// <summary>
    /// Наименование группы
    /// </summary>
    [Required, MaxLength(ModelConstants.Labs.Name)]
    public string Name { get; set; }
}
