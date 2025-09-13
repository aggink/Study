using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Officer.DtoModels;

public sealed record CreateOfficerDto
{
    //Имя
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]

    public string Name { get; init; }
    //Фамилия
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]

    public string SurName { get; init; }
    //Должность
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]

    public string Rank { get; init; }

}
