using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PoliceDepartament;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PoliceDepartament.Intern.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Intern.DtoModels;

public sealed record UpdateInternDto
{
    [Required]
    public Guid IsnIntern { get; set; }

    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]

    public string Name { get; set; }

    //Фамилия
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]
    public string SurName { get; set; }

    //Уровень подготовки
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]
    public string SkillLevel { get; set; }
}

