using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Employee.DtoModels;

public sealed record CreateEmployeeDto
{
    //Имя
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]

    public string Name { get; init; }
    //Фамилия
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]

    public string SurName { get; init; }
    //Работа
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]

    public string Work {  get; init; }

}
