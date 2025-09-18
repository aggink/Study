using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Employee.DtoModels;

public sealed record UpdateEmployeeDto
{
    [Required]
    public Guid IsnEmployee {  get; set; }

    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]

    public string Name { get; set; }

    //Фамилия
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]
    public string SurName { get; set; }

    //Работа
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]
    public string Work { get; set; }
}
