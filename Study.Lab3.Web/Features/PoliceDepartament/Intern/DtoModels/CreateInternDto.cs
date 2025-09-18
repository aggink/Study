using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Intern.DtoModels;

public sealed record CreateInternDto
{
    //Имя
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]

    public string Name { get; init; }
    //Фамилия
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]

    public string SurName { get; init; }
    //Уровень подготвоки
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]

    public string SkillLevel { get; init; }

}