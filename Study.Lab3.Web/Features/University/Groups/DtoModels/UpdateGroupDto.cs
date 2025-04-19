using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Groups.DtoModels;

public sealed record UpdateGroupDto
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Required]
    public Guid IsnGroup { get; set; }

    /// <summary>
    /// Наименование группы
    /// </summary>
    [Required, MaxLength(ModelConstants.Group.Name)]
    public string Name { get; set; }
}
