using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Officer.DtoModels;

public sealed record UpdateOfficerDto
{
    [Required]
    public Guid IsnOfficer { get; set; }

    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]

    public string Name { get; set; }

    //Фамилия
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]
    public string SurName { get; set; }

    //Должность
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]
    public string Rank { get; set; }
}
